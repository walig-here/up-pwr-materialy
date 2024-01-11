using System.IO;
using System.Runtime.Intrinsics.Arm;
using WIA;

namespace skaner
{
    public partial class Form1 : Form
    {
        DeviceManager deviceManager = new DeviceManager();
        List<DeviceInfo> availableScanners = new List<DeviceInfo>();

        public Form1()
        {
            InitializeComponent();
            picturePanel.Controls.Add(picture);

            // pobranie dostêpnych skanerów
            for (int i = 0; i < deviceManager.DeviceInfos.Count; i++)
            {
                try
                {
                    if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
                    {
                        scannerBox.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                        availableScanners.Add(deviceManager.DeviceInfos[i]);
                    }
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    continue;
                }
            }
            if (availableScanners.Count == 0)
            {
                MessageBox.Show("Nie znaleziono skanerów!");
                Close();
            }
            scannerBox.SelectedIndex = 0;
        }

        private void scan()
        {
            if(filePathBox.Text == "")
            {
                MessageBox.Show("Brak scie¿ki do pliku!");
                return;
            }
            if (File.Exists(filePathBox.Text + "\\scan.jpeg"))
            {
                File.Delete(filePathBox.Text + "\\scan.jpeg");
            }

            // po³¹czenie z wybranym skanerem
            if (scannerBox.SelectedItem == null)
            {
                MessageBox.Show("Ne wybrano skanera!");
                return;
            }
            var scanner = availableScanners[scannerBox.SelectedIndex].Connect();
            if(scanner == null)
            {
                MessageBox.Show("Nie mo¿na po³¹czyæ siê z wybranym skanerem!");
                return;
            }

            var image = (ImageFile) scanner.Items[1].Transfer(FormatID.wiaFormatJPEG);

            image.SaveFile(filePathBox.Text + "\\scan.jpeg");
            picture.ImageLocation = filePathBox.Text+"\\scan.jpeg"; 
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            scan();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            filePathBox.Text = dialog.SelectedPath;
        }
    }
}