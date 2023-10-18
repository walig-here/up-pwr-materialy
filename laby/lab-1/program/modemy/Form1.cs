using System.IO.Ports;
using System.Web;

namespace modemy
{

    public partial class Form1 : Form
    {
        /*
         * Tryby pracy w trakcie po³¹czenia z zewnêtrznym modemem
         */
        private enum Mode
        {
            no_connection,  // po³¹czenie z zewnêtrznym modemem nie jest nawi¹zane
            messages,       // tryb pisania wiadomoœci
            commands        // tryb pisania komend
        }

        /*
         * Zbiór komend Hayesa
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
         * Wykonanie po³¹czenia zewnêtrznego 
         */
        private void btn_call_Click(object sender, EventArgs e)
        {
            // sprawdzenie poprawnoœci podanego numeru
            string external_modem_number = txb_receiver_number.Text;
            if(String.IsNullOrEmpty(external_modem_number) || !external_modem_number.All(Char.IsDigit))
            {
                MessageBox.Show("Podany numer jest niepoprawny!");
                return;
            }

            // wykonanie po³¹czenia
            issueCommand(HayesCommand.call);
            printLineOnTerminal("£¹czenie z modemem o numerze " + external_modem_number + "...");
        }

        private void btn_hang_Click(object sender, EventArgs e)
        {

        }


        /*
         * Odebranie po³¹czenia zewnêtrznego 
         */
        private void btn_answer_Click(object sender, EventArgs e)
        {
            // odebranie po³¹czenia
            issueCommand(HayesCommand.answer_call);
            printLineOnTerminal("Odebrano po³¹czenie z modemu zewnêtrznego!");
        }


        /*
         * Otwarcie po³¹czenia szeregowego z modemem.
         */
        private void btn_port_connect_Click(object sender, EventArgs e)
        {
            // otwarcie po³¹czenia
            _serial_port.Open();

            // sprawdzenie po³¹czenia
            /*if (_serial_port.IsOpen && !isModemProperlyConnected())
            {
                MessageBox.Show("Nie uda³o siê nawi¹zaæ po³¹czenia!");
                _serial_port.Close();
                return;
            }*/

            // aktualizacja przycisków steruj¹cych po³¹czeniem z modemem
            btn_port_connect.Enabled = false;
            btn_port_disconnect.Enabled = true;

            // odblokowanie mo¿liwoœci nawi¹zywania po³¹czeñ miêdzy modemami
            btn_call.Enabled = true;
        }


        /*
         * Zamkniêcie po³¹czenia szeregowego z modemem 
         */
        private void btn_port_disconnect_Click(object sender, EventArgs e)
        {
            // zamkniêcie po³¹czenia z modemami zewnêtrznymi
            issueCommand(HayesCommand.hang);

            // zamkniêcie po³¹czenia
            _serial_port.Close();

            // wyczyszczenie pola terminala
            clearTerminal();

            // aktualizacja przycisków steruj¹cych po³¹czeniem z modemem
            btn_port_connect.Enabled = true;
            btn_port_disconnect.Enabled = false;

            // zablokowanie mo¿liwoœci zarz¹dzania po³¹czeniami z innymi modemami
            btn_answer.Enabled = btn_call.Enabled = btn_hang.Enabled = false;
        }


        /*
         * Wys³anie komendy do modemu  
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
         * Drukuje wiadomoœæ w polu terminala (komunikacja)
         */
        private void printLineOnTerminal(string message)
        {
            txb_terminal.Text += message + "\n\r";
        }


        /*
         * Usuwa ca³¹ zawartoœæ pola terminala (komunikacja) 
         */
        private void clearTerminal() 
        {
            txb_terminal.Text = "";
        }


        /*
         * Zwraca prawdê, gdy modem jej poprawnie po³¹czony z komputerem
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