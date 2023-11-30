namespace JoystickApp
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.available_devices_list = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.active_device = new System.Windows.Forms.ListBox();
            this.atctivate_button = new System.Windows.Forms.Button();
            this.deactivate_device = new System.Windows.Forms.Button();
            this.refresh_list = new System.Windows.Forms.Button();
            this.drawing_panel = new System.Windows.Forms.Panel();
            this.clear_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.axes_list = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.state_list = new System.Windows.Forms.ListBox();
            this.joystick_timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SuspendLayout();
            // 
            // available_devices_list
            // 
            this.available_devices_list.FormattingEnabled = true;
            this.available_devices_list.HorizontalScrollbar = true;
            this.available_devices_list.Location = new System.Drawing.Point(8, 25);
            this.available_devices_list.Name = "available_devices_list";
            this.available_devices_list.Size = new System.Drawing.Size(316, 43);
            this.available_devices_list.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dostępne urządzenia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Aktywne urządzenie";
            // 
            // active_device
            // 
            this.active_device.FormattingEnabled = true;
            this.active_device.Location = new System.Drawing.Point(7, 87);
            this.active_device.Name = "active_device";
            this.active_device.Size = new System.Drawing.Size(312, 17);
            this.active_device.TabIndex = 3;
            // 
            // atctivate_button
            // 
            this.atctivate_button.Location = new System.Drawing.Point(46, 110);
            this.atctivate_button.Name = "atctivate_button";
            this.atctivate_button.Size = new System.Drawing.Size(113, 28);
            this.atctivate_button.TabIndex = 4;
            this.atctivate_button.Text = "Aktywuj urządzenie";
            this.atctivate_button.UseVisualStyleBackColor = true;
            this.atctivate_button.Click += new System.EventHandler(this.atctivate_button_Click);
            // 
            // deactivate_device
            // 
            this.deactivate_device.Location = new System.Drawing.Point(102, 508);
            this.deactivate_device.Name = "deactivate_device";
            this.deactivate_device.Size = new System.Drawing.Size(127, 27);
            this.deactivate_device.TabIndex = 5;
            this.deactivate_device.Text = "Dezaktywuj urządzenie";
            this.deactivate_device.UseVisualStyleBackColor = true;
            this.deactivate_device.Click += new System.EventHandler(this.deactivate_device_Click);
            // 
            // refresh_list
            // 
            this.refresh_list.Location = new System.Drawing.Point(165, 111);
            this.refresh_list.Name = "refresh_list";
            this.refresh_list.Size = new System.Drawing.Size(112, 27);
            this.refresh_list.TabIndex = 6;
            this.refresh_list.Text = "Odśwież listę";
            this.refresh_list.UseVisualStyleBackColor = true;
            this.refresh_list.Click += new System.EventHandler(this.refresh_list_Click);
            // 
            // drawing_panel
            // 
            this.drawing_panel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawing_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawing_panel.Location = new System.Drawing.Point(330, 25);
            this.drawing_panel.Name = "drawing_panel";
            this.drawing_panel.Size = new System.Drawing.Size(615, 475);
            this.drawing_panel.TabIndex = 7;
            this.drawing_panel.Click += new System.EventHandler(this.drawing_panel_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(565, 508);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(155, 27);
            this.clear_button.TabIndex = 8;
            this.clear_button.Text = "Wyczyść kanwę";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kanwa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Osie";
            // 
            // axes_list
            // 
            this.axes_list.FormattingEnabled = true;
            this.axes_list.Location = new System.Drawing.Point(8, 158);
            this.axes_list.Name = "axes_list";
            this.axes_list.Size = new System.Drawing.Size(312, 30);
            this.axes_list.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Stan";
            // 
            // state_list
            // 
            this.state_list.FormattingEnabled = true;
            this.state_list.Location = new System.Drawing.Point(8, 210);
            this.state_list.Name = "state_list";
            this.state_list.Size = new System.Drawing.Size(311, 290);
            this.state_list.TabIndex = 14;
            // 
            // joystick_timer
            // 
            this.joystick_timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 547);
            this.Controls.Add(this.state_list);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.axes_list);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.drawing_panel);
            this.Controls.Add(this.refresh_list);
            this.Controls.Add(this.deactivate_device);
            this.Controls.Add(this.atctivate_button);
            this.Controls.Add(this.active_device);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.available_devices_list);
            this.Name = "Form1";
            this.Text = "Joystick";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox available_devices_list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox active_device;
        private System.Windows.Forms.Button atctivate_button;
        private System.Windows.Forms.Button deactivate_device;
        private System.Windows.Forms.Button refresh_list;
        private System.Windows.Forms.Panel drawing_panel;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox axes_list;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox state_list;
        private System.Windows.Forms.Timer joystick_timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

