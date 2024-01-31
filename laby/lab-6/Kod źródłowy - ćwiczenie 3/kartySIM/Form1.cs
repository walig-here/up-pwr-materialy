using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCSC;

namespace kartySIM
{
    public partial class Form1 : Form
    {
        SCardReader reader;
        SCardContext context = new SCardContext();

        public Form1()
        {
            InitializeComponent();
            sendCommandButton.Enabled = false;
            if (!getReaders())
                System.Environment.Exit(0);
        }

        bool getReaders()
        {
            context.Establish(SCardScope.System);
            string[] availableReaders = context.GetReaders();
            if(availableReaders.Length == 0)
            {
                MessageBox.Show("Brak czytnika");
                return false;
            }
            foreach (var availableReader in availableReaders)
            {
                readerList.Items.Add(availableReader);
            }

            readerList.SelectedIndex = 0;
            return true;
        }

        void parseAtr(byte[] atr)
        {
            string atrStr = "";
            if (atr[0] == 0x3b)
                atrStr += "Direct Convention";
            else if (atr[0] == 0x3f)
                atrStr += "Inverse Convention";
            atrStr += ", ";

            atrStr += "Protokół T" + (atr[3] % 16).ToString() + ", ";

            int historical_bytes = atr[1] % 16;
            atrStr += (atr[1]%16).ToString() + " znaków historycznych: ";
            for (int i = 7; i < 7 + historical_bytes; i++)
                atrStr += atr[i] + " ";

            responseBoxAscii.Text = atrStr;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            reader = new SCardReader(context);           
            SCardError error = reader.Connect(readerList.SelectedItem.ToString(), SCardShareMode.Shared, SCardProtocol.T0 | SCardProtocol.T1);
          
            if (!checkCardError(error))
                return;
            
            if (reader.ActiveProtocol != SCardProtocol.T0 && reader.ActiveProtocol != SCardProtocol.T1)
            {
                MessageBox.Show("Aktywny protokół nie jest odbługiwany!");
                sendCommandButton.Enabled = false;
            }
            else
            {
                MessageBox.Show("Połączono z kartą");
                sendCommandButton.Enabled = true;
                byte[] buffer;
                reader.GetAttrib(SCardAttribute.AnswerToResetString, out buffer);
                printToRespondeBox(buffer);
                parseAtr(buffer);
            }
        }

        void sendCommand()
        {
            string commandString = commandList.SelectedItem.ToString();
            byte[] command = new byte[] { };
            byte[] response = new byte[256];
            switch (commandString)
            {
                case "select file telecom":
                    command = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x7F, 0x10 };
                    break;
                case "select file adn":
                    command = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x6f, 0x3a };
                    break;
                case "select file mf":
                    command = new byte[] { 0xA0, 0xA4, 0x00, 0x00, 0x02, 0x3f, 0x00 };
                    break;
                case "read record":
                    command = new byte[] { 0xA0, 0xB2, 0x00, 0x04, 0x1C};
                    break;
                case "get response":
                    command = new byte[] { 0xa0, 0xc0, 0x00, 0x00, 0xFF};
                    break;
                default:
                    MessageBox.Show("Nieprawidłowa komenda");
                    return;
            }
            SCardError error = reader.Transmit(command, ref response);
            if (!checkCardError(error))
                return;
            printToRespondeBox(response);
        }

        bool checkCardError(SCardError error)
        {
            if(error != SCardError.Success)
            {
                MessageBox.Show("Wystąpił błąd karty: " + error.ToString());
                return false;
            }
            return true;
        }

        private void sendCommandButton_Click(object sender, EventArgs e)
        {
            if (commandList.SelectedItem != null)
                sendCommand();
            else
                MessageBox.Show("Pole komendy jest puste");
        }

        void printToRespondeBox(byte[] response)
        {
            string answerStrHex = BitConverter.ToString(response).Replace("-", " ");
            responseBoxHex.Text = answerStrHex;
            
            string answerStrAscii = "";
            switch (response[0])
            {
                case 0x9f:
                    answerStrAscii = "Komenda wykonała się poprawnie. Pozostało " + response[1] + " bajtów odpowiedzi.";
                    break;
                default:
                    answerStrAscii = System.Text.Encoding.ASCII.GetString(response);
                    break;
            }
            responseBoxAscii.Text = answerStrAscii;
        }
    }
}
