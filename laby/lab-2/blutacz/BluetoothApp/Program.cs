// See https://aka.ms/new-console-template for more information
using System;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace BluetoothApp
{
    class App
    {
        BluetoothDeviceInfo[] scanForDevices()
        {
            Console.WriteLine("Scanning for devices...");
            BluetoothClient this_machine = new BluetoothClient();
            return this_machine.DiscoverDevices();
        }

        bool pairDevice(BluetoothDeviceInfo device)
        {
            if(!device.Authenticated)
            {
                Console.WriteLine("Pairing...");
                if(!BluetoothSecurity.PairRequest(device.DeviceAddress, null))
                {
                    Console.WriteLine("Pairing failed!");
                    return false;
                }
            }
            Console.WriteLine("Devices paired");
            return true;
        }

        void sendFile(string file_path, BluetoothDeviceInfo receiver)
        {
            ObexWebRequest request = new ObexWebRequest(new Uri(String.Format("obex://{0}/{1}", receiver.DeviceAddress, file_path)));
            request.ReadFile(file_path);

            ObexWebResponse response = (ObexWebResponse) request.GetResponse();
            response.Close();

            if(response.StatusCode == (ObexStatusCode.OK | ObexStatusCode.Final))
                Console.WriteLine("File sent!");
            else if(response.StatusCode == (ObexStatusCode.Forbidden | ObexStatusCode.Final))
                Console.WriteLine("File transfer denied!");
        }

        static void Main()
        {
            if(!BluetoothRadio.IsSupported)
            {
                Console.WriteLine("Bluetooth is not enabled!");
                return;
            }

            App app = new App();
            BluetoothDeviceInfo[] found_devices = app.scanForDevices();

            Console.WriteLine("Discovered devices:");
            foreach(var device in found_devices)
            {
                Console.Write(  $"Name: {device.DeviceName}\t" +
                                $"Address: {device.DeviceAddress}\t" +
                                $"Paired: {device.Authenticated}\n");
            }

            if(found_devices.Length == 0)
            {
                Console.WriteLine("No devices found!");
                return;
            }

            // Send file
            try
            {
                Console.Write("Nazwa pliku: ");
                string file_path = Console.ReadLine();
                foreach(var device in found_devices)
                {
                    if(!app.pairDevice(device))
                        return;
                    app.sendFile(file_path, device);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}