using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using InTheHand.Net;

namespace blutetooth
{
    

    public partial class Form1 : Form
    {
        BluetoothDeviceInfo[] discovered_devices;

        public Form1()
        {
            InitializeComponent();
            if(!BluetoothRadio.IsSupported)
            {
                MessageBox.Show("Bluetooth nieaktywny!");
            }
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            string path = dialog.FileName;
            files_to_send_display.Items.Add(path);
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (discovered_devices == null)
                return;
            if (files_to_send_display.SelectedItem == null || found_devices_display.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano pliku bądź urządzenia!");
                return;
            }
            string filename = files_to_send_display.SelectedItem.ToString();
            sendFileToDevice(filename, discovered_devices[found_devices_display.SelectedIndex]);
        }

        void sendFileToDevice(string file, BluetoothDeviceInfo device)
        {
            try
            {
                ObexWebRequest request = new ObexWebRequest(new Uri(String.Format("obex://{0}/{1}", device.DeviceAddress, file)));
                request.ReadFile(file);

                ObexWebResponse response = (ObexWebResponse)request.GetResponse();

                if (response.StatusCode == (ObexStatusCode.OK | ObexStatusCode.Final))
                    MessageBox.Show("Plik wysłany!");
                else if (response.StatusCode == (ObexStatusCode.Forbidden | ObexStatusCode.Final))
                    MessageBox.Show("Plik niewysłany! Odmowa dostępu do urządzenia.");
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}");
            }
        }

        void updateFoundDevicesDisplay()
        {
            found_devices_display.Items.Clear();
            foreach (var device in discovered_devices)
            {
                found_devices_display.Items.Add(device.DeviceName + "\t" + (device.Authenticated ? "Sparowano" : ""));
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            lookForDevices();
            updateFoundDevicesDisplay();
        }

        private void btn_pair_Click(object sender, EventArgs e)
        {
            if (found_devices_display.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano urządzenia!");
                return;
            }
            BluetoothDeviceInfo end_device = discovered_devices[found_devices_display.SelectedIndex];
            if(!end_device.Authenticated)
            {
                if(!BluetoothSecurity.PairRequest(end_device.DeviceAddress, "1"))
                {
                    MessageBox.Show("Parowanie nieudane!");
                    return;
                }
            }
            MessageBox.Show("Sparowano!");
            lookForDevices();
            updateFoundDevicesDisplay();
        }

        private void btn_unpair_Click(object sender, EventArgs e)
        {
            if (!unpairDevice(discovered_devices[found_devices_display.SelectedIndex]))
                return;
            lookForDevices();
            updateFoundDevicesDisplay();
        }

        bool unpairDevice(BluetoothDeviceInfo device)
        {
            if (device.Authenticated)
            {
                if (!BluetoothSecurity.RemoveDevice(device.DeviceAddress))
                {
                    MessageBox.Show("Nie rozparowano!");
                    return false;
                }
                MessageBox.Show("Rozparowano!");
                return true;
            }
            return false;
        }

        private void lookForDevices()
        {
            BluetoothClient this_machine = new BluetoothClient();
            discovered_devices = this_machine.DiscoverDevices();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (discovered_devices == null)
                return;
            foreach(var device in discovered_devices)
            {
                unpairDevice(device);    
            }
        }
    }
}
