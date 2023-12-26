using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO.Ports;
using System.Globalization;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        SerialPort gps;

        public Form1()
        {
            InitializeComponent();
            gps = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            gps.Open();
            gps_timer.Enabled = true;
        }

        private void openMapsButton_Click(object sender, EventArgs e)
        {
            string url = "https://www.google.pl/maps/place/" + longtitude.Text + "+" + latitude.Text;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        string[] getMessagesFromBuffer(byte[] buffer)
        {
            string message_ascii = System.Text.Encoding.ASCII.GetString(buffer);
            return message_ascii.Split('\n');
        }

        bool isRmcMessage(string message)
        {
            return message.Contains("$GPRMC,");
        }

        string getDegrees(string data, int digitsForDegrees)
        {
            int degrees = int.Parse(data.Substring(0, digitsForDegrees));
            return degrees.ToString() + "°";
        }

        string getMinutesAndSeconds(string data, int digitsForDegrees)
        {
            CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.CurrencyDecimalSeparator = ".";
            int minutes = (int) float.Parse(data.Substring(digitsForDegrees), CultureInfo.InvariantCulture.NumberFormat);
            int seconds = (int)((float.Parse(data.Substring(digitsForDegrees), CultureInfo.InvariantCulture.NumberFormat) - minutes) * 60);
            return minutes.ToString() + "'" + seconds.ToString() + "\"";
        }

        string getTimeUCT1(string data)
        {
            int a = int.Parse(data.Substring(0, 2)) + 1;
            string hours = a.ToString() + ":";
            string minutes = data.Substring(2, 2) + ":";
            string seconds = data.Substring(4, 2);
            return hours + minutes + seconds;
        }

        DateTime addWeeksToDate(DateTime startDate, int weeks)
        {
            return startDate.AddDays(7 * weeks);
        }

        string getDate(string data)
        {
            string day = data.Substring(0, 2);
            string month = data.Substring(2, 2);
            string year = data.Substring(4, 2);

            DateTime date =  DateTime.ParseExact(day + "-" + month + "-" + year, "dd-MM-yy", CultureInfo.InvariantCulture);
            date = addWeeksToDate(date, 1024);
            return date.ToString().Substring(0,10);
        }

        void fillGuiWithDateAndPositionData(string message)
        {
            string[] dataFields = message.Split(',');
            latitude.Text = getDegrees(dataFields[3], 2) + getMinutesAndSeconds(dataFields[3], 2) + dataFields[4];
            longtitude.Text = getDegrees(dataFields[5], 3) + getMinutesAndSeconds(dataFields[5], 3) + dataFields[6];
            time.Text = getTimeUCT1(dataFields[1]);
            date.Text = getDate(dataFields[9]);
        }

        void fillGuiWithAmountOfSatelites(string message)
        {
            string[] dataFields = message.Split(',');
            amount_of_satelites.Text = dataFields[7];
        }

        bool isGgaMessage(string message)
        {
            return message.Contains("$GPGGA");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1000];
            gps.Read(buffer, 0, 1000);
            string[] messages = getMessagesFromBuffer(buffer);
            foreach (var message in messages)
            {
                if (isRmcMessage(message))
                    fillGuiWithDateAndPositionData(message);
                else if (isGgaMessage(message))
                    fillGuiWithAmountOfSatelites(message);   
            }
        }
    }
}
