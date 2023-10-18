using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ModemModem
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '3';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '4';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '5';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '6';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '7';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '8';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '9';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text += '0';
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if(textBoxPhoneNumber.Text.Length > 0)
            textBoxPhoneNumber.Text = textBoxPhoneNumber.Text.Substring(0, textBoxPhoneNumber.Text.Length - 1);
        }

        private void buttonCall_Click(object sender, EventArgs e)
        {
            string comendCall = "atd" + textBoxPhoneNumber.Text + "\r";
            /*var data = new byte[comendCall.Length];
            for (int i = 0; i < comendCall.Length; i++)
            {
                data[i] = (byte)comendCall[i];
            }
            Program._serialPort.Write(data, 0, data.Length);
            */
            MessageBox.Show(comendCall, "numer");
            _serialPort.Write(comendCall);
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            string comendCall = "+++ath\r";
            MessageBox.Show(comendCall, "ending CALL");
            _serialPort.Write(comendCall);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = _serialPort.ReadExisting();
            if (data.Contains("CON"))
            {
                polaczono = true;
                WypiszNaEkran("Polaczono z drugim modemem.");
            }
            WypiszNaEkran("<-" + data + "\n");
            }

        public void WypiszNaEkran(string data)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MethodInvoker(
                    delegate ()
                    {
                        textBox1.Text += data + "\r";

                        textBox1.SelectionStart = textBox1.TextLength;
                        textBox1.ScrollToCaret();
                    }));


            }
        }
        private void buttonClosePort_Click(object sender, EventArgs e)
        {
            _serialPort.Close();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            string comendCall = "ata\r";
            MessageBox.Show("","ACCEPT CALL");
            _serialPort.Write(comendCall);
        }
        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            _serialPort.Open();
            _serialPort.DataReceived += dataReceived;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            _serialPort.Write(textBoxSend.Text + "\r");
        }
    }
}
