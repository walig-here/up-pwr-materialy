using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ModemModem
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///[STAThread]

        //public static SerialPort _serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        static void Main()
        {
            //_serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            //_serialPort.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
