using System.Diagnostics;

namespace lab4_gps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.google.com/maps/place/" + long_field.Text + "+" + lat_field.Text;
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}