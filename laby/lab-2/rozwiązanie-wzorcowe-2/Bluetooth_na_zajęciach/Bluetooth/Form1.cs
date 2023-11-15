﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Threading;

namespace Bluetooth
{
    public partial class Form1 : Form
    {
        public const string DEVICE_PIN = "000000";
        private bool continueScanning = false;
        private bool isPaired = false;
        private bool isUnpaired = false;
        private List<BluetoothDeviceInfo> devices = new List<BluetoothDeviceInfo>();
        BluetoothDeviceInfo deviceToPair = null;

        public Form1()
        {
            InitializeComponent();
            textBoxConsole.ReadOnly = true;
        
        }
        // Funkcja wyszukująca urządzenia oraz ich typ i adres
        private void ScanDevices()
        {
            try
            {
                while(continueScanning)
                {
                    var bluetoothClient = new BluetoothClient();
                    var bluetoothDevices = bluetoothClient.DiscoverDevices();

                    foreach(var bluetoothDevice in bluetoothDevices)
                    {
                        var bluetoothInfo = string.Format("Nazwa urządzenia: {0}\r\nTyp urządzenia: {1} Adres: {2}",
                            bluetoothDevice.DeviceName, bluetoothDevice.ClassOfDevice.Device,bluetoothDevice.DeviceAddress);

                        textBoxConsole.Text += bluetoothInfo + "\r\n";

                        bool onList = false;

                        if(bluetoothDevice.DeviceName!=null)
                        {
                            foreach (string item in listBoxDevices.Items)
                                if (item == bluetoothDevice.DeviceName)
                                    onList = true;
                        }

                        if(!onList)
                        {
                            listBoxDevices.Items.Add(bluetoothDevice.DeviceName);
                            devices.Add(bluetoothDevice);
                        }
                    }
                }
            }
            catch(Exception error)
            {
                textBoxConsole.Text += "Wystąpił błąd!\r\n" + error.Message + "\r\n";
            }

        }
        // funkcja która wywołuje szukanie urządzeń po kliknięciu przycisku
        private void buttonFindDevices_Click(object sender, EventArgs e)
        {
            Thread findDevices = new Thread(ScanDevices);
            findDevices.Priority = ThreadPriority.Highest;
            findDevices.IsBackground = true;
            findDevices.Start();

            if(buttonFindDevices.Text == "Szukaj urządzeń")
            {
                buttonFindDevices.Text = "Zatrzymaj wyszukiwanie";
                continueScanning = true;
                textBoxConsole.Text += ("Szukam urządzeń.\r\n");
            }
            else
            {
                buttonFindDevices.Text = "Szukaj urządzeń";
                continueScanning = false;
                textBoxConsole.Text += "Wyszukiwanie zakończone.\r\n";
            }
        }

        // Funkcja pozwalająca na odbieranie plików
        private void ReceiveFiles()
        {
            while (isPaired)
            {
                var listener = new ObexListener(ObexTransport.Bluetooth);
                listener.Start();
                ObexListenerContext ctx = listener.GetContext();
                ObexListenerRequest req = ctx.Request;
                String[] pathSplits = req.RawUrl.Split('/');
                String file = pathSplits[pathSplits.Length - 1];
                req.WriteFile(file);
                textBoxConsole.Text += "Odebrano plik.\r\n";
                listener.Stop();
            }
        }
        //Funkcja parująca urządzenia
        private void PairWithDevice()
        {
            foreach(var device in devices)
            {
                if (device.DeviceName == (string)listBoxDevices.SelectedItem)
                    deviceToPair = device;
            }

            if(deviceToPair==null)
            {
                textBoxConsole.Text += "Nie zaznaczyłeś z którym urządzeniem chcesz się połączyć!\r\n";
            }
            else
            {
                textBoxConsole.Text += "Łączenie z: " + (string)deviceToPair.DeviceName + "\r\n";
                deviceToPair.Update();
                deviceToPair.Refresh();
                deviceToPair.SetServiceState(BluetoothService.ObexObjectPush, true);
                isPaired = BluetoothSecurity.PairRequest(deviceToPair.DeviceAddress, DEVICE_PIN);
                if(isPaired)
                {
                    textBoxConsole.Text += "Sparowano urządzenie.\r\n";
                    listBoxConnected.Items.Add(deviceToPair.DeviceName);
                    buttonPairWithDevice.Enabled = false;
                    buttonUnpair.Enabled = true;

                    Thread receiveFiles = new Thread(ReceiveFiles);
                    receiveFiles.Priority = ThreadPriority.Highest;
                    receiveFiles.IsBackground = true;
                    receiveFiles.Start();
                }
                else
                {
                    textBoxConsole.Text += "Nie sparowano.\r\n";
                }
            }
        }
        //Funkcja rozparowująca urządzenia
        private void Unpair()
        {
            if (deviceToPair.DeviceName == listBoxConnected.SelectedItem.ToString())
                isUnpaired = BluetoothSecurity.RemoveDevice(deviceToPair.DeviceAddress);
                    
            if(isUnpaired)
            {
                textBoxConsole.Text += "Rozłączono.\r\n";
                listBoxConnected.Items.Remove(deviceToPair.DeviceName);
                isPaired = false;
            }
            else
            {
                textBoxConsole.Text += "Nie udało się rozłączyć urządzenia.\r\n";
            }
        }

        private void buttonPairWithDevice_Click(object sender, EventArgs e)
        {
            Thread pairWithDevice = new Thread(PairWithDevice);
            pairWithDevice.Priority = ThreadPriority.Highest;
            pairWithDevice.IsBackground = true;
            pairWithDevice.Start();
        }

        private void buttonUnpair_Click(object sender, EventArgs e)
        {
            Unpair();
            buttonPairWithDevice.Enabled = true;
            buttonUnpair.Enabled = false;
        }

        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            openFile.ShowDialog();
        }

        //Funkcja pozwalająca na wybranie pliku który chcemy wysłać
        private void openFile_FileOk(object sender, CancelEventArgs e)
        {
            bool exist = false;
            foreach (var fileName in openFile.FileNames)
            {
                if (fileName != null)
                {
                    foreach (string item in listBoxFiles.Items)
                        if (item == fileName)
                            exist = true;
                }

                if (!exist)
                {
                    listBoxFiles.Items.Add(fileName);
                }
                else
                {
                    MessageBox.Show("");
                }
            }
        }

 

        // Funkcja wysyłająca plik do sparowanego urządzenia
        private void SendFiles()
        {
            foreach(string file in listBoxFiles.Items)
            {
                try
                {
                    if(deviceToPair!=null)        
                    textBoxConsole.Text += ("Wysyłanie pliku\r\n");
                    var uri = new Uri("obex://" + deviceToPair.DeviceAddress + "/" + file);
                    var request = new ObexWebRequest(uri);
                    request.ReadFile(file);
                    var response = (ObexWebResponse)request.GetResponse();
                    textBoxConsole.Text += ("Pomyślnie wysłano plik:" + file + "\r\n");
                }
                catch(Exception error)
                {
                    textBoxConsole.Text += "Wystapił błąd! " + error.Message + "\r\n";
                }
            }
            listBoxFiles.Items.Clear();
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            Thread sendFiles = new Thread(SendFiles);
            sendFiles.Priority = ThreadPriority.Highest;
            sendFiles.IsBackground = true;
            sendFiles.Start();
        }

        private void textBoxConsole_TextChanged(object sender, EventArgs e)
        {
            textBoxConsole.SelectionStart = textBoxConsole.Text.Length;
            textBoxConsole.ScrollToCaret();
        }

        private void textBoxReceivedFiles_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
