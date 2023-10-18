using System.IO.Ports;
using System.Web;

namespace modemy
{

    public partial class Form1 : Form
    {
        /*
         * Tryby pracy w trakcie po��czenia z zewn�trznym modemem
         */
        private enum Mode
        {
            no_connection,  // po��czenie z zewn�trznym modemem nie jest nawi�zane
            messages,       // tryb pisania wiadomo�ci
            commands        // tryb pisania komend
        }

        /*
         * Zbi�r komend Hayesa
         */
        private enum HayesCommand
        {
            check_conection,
            call,
            hang,
            exit_command_mode,
            answer_call,
            enter_command_mode
        }

        private SerialPort _serial_port;    // port szeregowy do komunikacji z modemem
        private Mode _mode;                 // aktualny tryb  

        public Form1()
        {
            _serial_port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            _mode = Mode.no_connection;
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {

        }

        private void lab_mode_Click(object sender, EventArgs e)
        {

        }

        private void btn_commands_Click(object sender, EventArgs e)
        {

        }

        private void btn_writing_Click(object sender, EventArgs e)
        {

        }

        /*
         * Wykonanie po��czenia zewn�trznego 
         */
        private void btn_call_Click(object sender, EventArgs e)
        {
            // sprawdzenie poprawno�ci podanego numeru
            string external_modem_number = txb_receiver_number.Text;
            if(String.IsNullOrEmpty(external_modem_number) || !external_modem_number.All(Char.IsDigit))
            {
                MessageBox.Show("Podany numer jest niepoprawny!");
                return;
            }

            // wykonanie po��czenia
            issueCommand(HayesCommand.call);
            printLineOnTerminal("��czenie z modemem o numerze " + external_modem_number + "...");
        }

        private void btn_hang_Click(object sender, EventArgs e)
        {

        }


        /*
         * Odebranie po��czenia zewn�trznego 
         */
        private void btn_answer_Click(object sender, EventArgs e)
        {
            // odebranie po��czenia
            issueCommand(HayesCommand.answer_call);
            printLineOnTerminal("Odebrano po��czenie z modemu zewn�trznego!");
        }


        /*
         * Otwarcie po��czenia szeregowego z modemem.
         */
        private void btn_port_connect_Click(object sender, EventArgs e)
        {
            // otwarcie po��czenia
            _serial_port.Open();

            // sprawdzenie po��czenia
            /*if (_serial_port.IsOpen && !isModemProperlyConnected())
            {
                MessageBox.Show("Nie uda�o si� nawi�za� po��czenia!");
                _serial_port.Close();
                return;
            }*/

            // aktualizacja przycisk�w steruj�cych po��czeniem z modemem
            btn_port_connect.Enabled = false;
            btn_port_disconnect.Enabled = true;

            // odblokowanie mo�liwo�ci nawi�zywania po��cze� mi�dzy modemami
            btn_call.Enabled = true;
        }


        /*
         * Zamkni�cie po��czenia szeregowego z modemem 
         */
        private void btn_port_disconnect_Click(object sender, EventArgs e)
        {
            // zamkni�cie po��czenia z modemami zewn�trznymi
            issueCommand(HayesCommand.hang);

            // zamkni�cie po��czenia
            _serial_port.Close();

            // wyczyszczenie pola terminala
            clearTerminal();

            // aktualizacja przycisk�w steruj�cych po��czeniem z modemem
            btn_port_connect.Enabled = true;
            btn_port_disconnect.Enabled = false;

            // zablokowanie mo�liwo�ci zarz�dzania po��czeniami z innymi modemami
            btn_answer.Enabled = btn_call.Enabled = btn_hang.Enabled = false;
        }


        /*
         * Wys�anie komendy do modemu  
         */
        private void issueCommand(HayesCommand command)
        {
            string command_str = "";
            switch(command)
            {
                case HayesCommand.exit_command_mode:
                    command_str += "ATO";
                    break;
                case HayesCommand.call:
                    command_str += "ATD";
                    command_str += txb_receiver_number.Text;
                    break;
                case HayesCommand.hang:
                    command_str += "ATH";
                    break;
                case HayesCommand.check_conection:
                    command_str += "AT";
                    break;
                case HayesCommand.enter_command_mode:
                    command_str += "+++";
                    break;
            }
            command_str += "\r";
            _serial_port.Write(command_str);
        }


        /*
         * Drukuje wiadomo�� w polu terminala (komunikacja)
         */
        private void printLineOnTerminal(string message)
        {
            txb_terminal.Text += message + "\n\r";
        }


        /*
         * Usuwa ca�� zawarto�� pola terminala (komunikacja) 
         */
        private void clearTerminal() 
        {
            txb_terminal.Text = "";
        }


        /*
         * Zwraca prawd�, gdy modem jej poprawnie po��czony z komputerem
         */
        private bool isModemProperlyConnected()
        {
            issueCommand(HayesCommand.check_conection);
            string modem_answer = _serial_port.ReadExisting();
            if (modem_answer.Contains("OK"))
                return true;
            else
                return false;
        }
    }
}