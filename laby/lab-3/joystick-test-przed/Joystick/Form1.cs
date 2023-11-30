using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace JoystickApp
{

    public partial class Form1 : Form
    {
        // -------------------------- LOGIC --------------------------- //

        DirectInput directInput;
        DeviceInstance[] available_devices;
        Joystick active_joystick;
        const float sensitivity = 1;

        // Wyliczenie wszystkich urządzeń
        void getAllAvailableDeives()
        {
            available_devices = directInput.GetDevices().ToArray();
        }

        // Próba aktywacji joysticka
        bool activateJoystick(DeviceInstance device)
        {
            if (active_joystick != null)
                return false;
            if (device == null || (device.Type != DeviceType.Gamepad && device.Type != DeviceType.Joystick))
                return false;

            active_joystick = new Joystick(directInput, device.InstanceGuid);
            active_joystick.Properties.BufferSize = 128;
            active_joystick.Acquire();

            return true;
        }

        bool deactivateJoystick()
        {
            if (active_joystick == null)
                return false;
            active_joystick.Unacquire();
            active_joystick = null;

            return true;
        }

        // --------------------------  GUI  --------------------------- //

        public Form1()
        {
            InitializeComponent();
            directInput = new DirectInput();
            active_joystick = null;

            getAllAvailableDeives();
            fillAvailableDevicesList();
        }

        private void fillAvailableDevicesList()
        {
            available_devices_list.Items.Clear();
            string device_data;
            foreach(var device in available_devices)
            {
                device_data = "Nazwa: ";
                device_data += device.InstanceName + " ";
                device_data += "Typ: ";
                device_data += device.Type + "\n";

                available_devices_list.Items.Add(device_data);
            }
        }

        void fillAxesList() 
        {
            // Lista osi
            axes_list.Items.Clear();
            int i = 0;
            foreach (var axis in active_joystick.GetObjects(DeviceObjectTypeFlags.Axis | DeviceObjectTypeFlags.RelativeAxis))
            {
                switch(i)
                {
                    case 0:
                        active_joystick.GetObjectPropertiesById(axis.ObjectId).Range 
                            = new InputRange(
                                0,
                                (int) (Screen.PrimaryScreen.Bounds.Height * sensitivity)
                            );
                        break;
                    case 1:
                        active_joystick.GetObjectPropertiesById(axis.ObjectId).Range 
                            = new InputRange(
                                0,
                                (int) (Screen.PrimaryScreen.Bounds.Width * sensitivity)
                            );
                        break;
                }
                axes_list.Items.Add
                (
                    "Oś " + i + ": " + axis.Name + 
                    " Zakres: " + active_joystick.GetObjectPropertiesById(axis.ObjectId).Range.Minimum + 
                    "-" + active_joystick.GetObjectPropertiesById(axis.ObjectId).Range.Maximum
                );
                i++;
            }
        }

        void fillStateList()
        {
            // Lista stanu
            state_list.Items.Clear();
            state_list.Items.Add("Pozycja X: " + active_joystick.GetCurrentState().X.ToString());
            state_list.Items.Add("Pozycja Y: " + active_joystick.GetCurrentState().Y.ToString());
            state_list.Items.Add("Pozycja Z: " + active_joystick.GetCurrentState().Z.ToString());
            int i = 1;
            foreach (var pov in active_joystick.GetCurrentState().PointOfViewControllers)
            {
                if (i > active_joystick.Capabilities.PovCount)
                    break;
                state_list.Items.Add("Pozycjometr " + i + ": " + pov);
                i++;
            }
            i = 1;
            foreach(var button in active_joystick.GetCurrentState().Buttons)
            {
                if (i > active_joystick.Capabilities.ButtonCount)
                    break;
                state_list.Items.Add("Przycisk " + i + ": " + (button ? "AKTYWNY" : "nieaktywny"));
                i++;
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {

        }

        private void refresh_list_Click(object sender, EventArgs e)
        {
            getAllAvailableDeives();
            fillAvailableDevicesList();
        }

        private void atctivate_button_Click(object sender, EventArgs e)
        {
            if (available_devices_list.SelectedItem == null)
                return;
            if(activateJoystick(available_devices[available_devices_list.SelectedIndex]))
            {
                active_device.Items.Add(available_devices[available_devices_list.SelectedIndex].InstanceName);
                fillAxesList();
                fillStateList();
                joystick_timer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Urządzenie nie jest joystickiem lub aktywne jest już inne urządzenie.");
            }
        }

        private void deactivate_device_Click(object sender, EventArgs e)
        {
            if(deactivateJoystick())
            {
                active_device.Items.Clear();
                state_list.Items.Clear();
                axes_list.Items.Clear();
                joystick_timer.Enabled = false;
            }
            else
            {
                MessageBox.Show("Brak urządzenia do dezaktywacji!");
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        private void timer1_Tick(object sender, EventArgs e)
        {
            fillStateList();
            JoystickState current_state = active_joystick.GetCurrentState();
            SetCursorPos(current_state.X, current_state.Y);

            if (current_state.Buttons[0])
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, current_state.X, current_state.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, current_state.X, current_state.Y, 0, 0);
            }
        }

        private void drawing_panel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
