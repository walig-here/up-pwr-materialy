namespace modemy
{
    partial class Form1 
    { 

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txb_terminal = new System.Windows.Forms.TextBox();
            this.txb_command_line = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.txb_receiver_number = new System.Windows.Forms.TextBox();
            this.btn_call = new System.Windows.Forms.Button();
            this.btn_hang = new System.Windows.Forms.Button();
            this.btn_answer = new System.Windows.Forms.Button();
            this.lab_chat = new System.Windows.Forms.Label();
            this.lab_receiver_number = new System.Windows.Forms.Label();
            this.btn_writing = new System.Windows.Forms.Button();
            this.btn_commands = new System.Windows.Forms.Button();
            this.lab_mode = new System.Windows.Forms.Label();
            this.btn_port_connect = new System.Windows.Forms.Button();
            this.btn_port_disconnect = new System.Windows.Forms.Button();
            this.lab_port_connection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txb_terminal
            // 
            this.txb_terminal.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txb_terminal.Location = new System.Drawing.Point(12, 54);
            this.txb_terminal.Multiline = true;
            this.txb_terminal.Name = "txb_terminal";
            this.txb_terminal.ReadOnly = true;
            this.txb_terminal.Size = new System.Drawing.Size(317, 300);
            this.txb_terminal.TabIndex = 0;
            // 
            // txb_command_line
            // 
            this.txb_command_line.Location = new System.Drawing.Point(12, 360);
            this.txb_command_line.Name = "txb_command_line";
            this.txb_command_line.Size = new System.Drawing.Size(236, 23);
            this.txb_command_line.TabIndex = 1;
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(254, 360);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 2;
            this.btn_send.Text = "Wyślij";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txb_receiver_number
            // 
            this.txb_receiver_number.Location = new System.Drawing.Point(345, 54);
            this.txb_receiver_number.Name = "txb_receiver_number";
            this.txb_receiver_number.Size = new System.Drawing.Size(288, 23);
            this.txb_receiver_number.TabIndex = 3;
            // 
            // btn_call
            // 
            this.btn_call.Enabled = false;
            this.btn_call.Location = new System.Drawing.Point(345, 83);
            this.btn_call.Name = "btn_call";
            this.btn_call.Size = new System.Drawing.Size(92, 23);
            this.btn_call.TabIndex = 4;
            this.btn_call.Text = "Zadzwoń\r\n";
            this.btn_call.UseVisualStyleBackColor = true;
            this.btn_call.Click += new System.EventHandler(this.btn_call_Click);
            // 
            // btn_hang
            // 
            this.btn_hang.Enabled = false;
            this.btn_hang.Location = new System.Drawing.Point(443, 83);
            this.btn_hang.Name = "btn_hang";
            this.btn_hang.Size = new System.Drawing.Size(92, 23);
            this.btn_hang.TabIndex = 5;
            this.btn_hang.Text = "Rozłącz";
            this.btn_hang.UseVisualStyleBackColor = true;
            this.btn_hang.Click += new System.EventHandler(this.btn_hang_Click);
            // 
            // btn_answer
            // 
            this.btn_answer.Enabled = false;
            this.btn_answer.Location = new System.Drawing.Point(541, 83);
            this.btn_answer.Name = "btn_answer";
            this.btn_answer.Size = new System.Drawing.Size(92, 23);
            this.btn_answer.TabIndex = 6;
            this.btn_answer.Text = "Odbierz";
            this.btn_answer.UseVisualStyleBackColor = true;
            this.btn_answer.Click += new System.EventHandler(this.btn_answer_Click);
            // 
            // lab_chat
            // 
            this.lab_chat.AutoSize = true;
            this.lab_chat.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lab_chat.Location = new System.Drawing.Point(12, 26);
            this.lab_chat.Name = "lab_chat";
            this.lab_chat.Size = new System.Drawing.Size(147, 25);
            this.lab_chat.TabIndex = 7;
            this.lab_chat.Text = "KOMUNIKACJA";
            // 
            // lab_receiver_number
            // 
            this.lab_receiver_number.AutoSize = true;
            this.lab_receiver_number.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lab_receiver_number.Location = new System.Drawing.Point(345, 26);
            this.lab_receiver_number.Name = "lab_receiver_number";
            this.lab_receiver_number.Size = new System.Drawing.Size(182, 25);
            this.lab_receiver_number.TabIndex = 8;
            this.lab_receiver_number.Text = "NUMER ODBIORCY";
            // 
            // btn_writing
            // 
            this.btn_writing.Enabled = false;
            this.btn_writing.Location = new System.Drawing.Point(345, 158);
            this.btn_writing.Name = "btn_writing";
            this.btn_writing.Size = new System.Drawing.Size(140, 23);
            this.btn_writing.TabIndex = 9;
            this.btn_writing.Text = "Wiadomości";
            this.btn_writing.UseVisualStyleBackColor = true;
            this.btn_writing.Click += new System.EventHandler(this.btn_writing_Click);
            // 
            // btn_commands
            // 
            this.btn_commands.Enabled = false;
            this.btn_commands.Location = new System.Drawing.Point(491, 158);
            this.btn_commands.Name = "btn_commands";
            this.btn_commands.Size = new System.Drawing.Size(140, 23);
            this.btn_commands.TabIndex = 10;
            this.btn_commands.Text = "Komendy\r\n";
            this.btn_commands.UseVisualStyleBackColor = true;
            this.btn_commands.Click += new System.EventHandler(this.btn_commands_Click);
            // 
            // lab_mode
            // 
            this.lab_mode.AutoSize = true;
            this.lab_mode.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lab_mode.Location = new System.Drawing.Point(345, 130);
            this.lab_mode.Name = "lab_mode";
            this.lab_mode.Size = new System.Drawing.Size(59, 25);
            this.lab_mode.TabIndex = 11;
            this.lab_mode.Text = "TRYB";
            this.lab_mode.Click += new System.EventHandler(this.lab_mode_Click);
            // 
            // btn_port_connect
            // 
            this.btn_port_connect.Location = new System.Drawing.Point(345, 244);
            this.btn_port_connect.Name = "btn_port_connect";
            this.btn_port_connect.Size = new System.Drawing.Size(140, 23);
            this.btn_port_connect.TabIndex = 12;
            this.btn_port_connect.Text = "Połącz";
            this.btn_port_connect.UseVisualStyleBackColor = true;
            this.btn_port_connect.Click += new System.EventHandler(this.btn_port_connect_Click);
            // 
            // btn_port_disconnect
            // 
            this.btn_port_disconnect.Enabled = false;
            this.btn_port_disconnect.Location = new System.Drawing.Point(491, 244);
            this.btn_port_disconnect.Name = "btn_port_disconnect";
            this.btn_port_disconnect.Size = new System.Drawing.Size(140, 23);
            this.btn_port_disconnect.TabIndex = 13;
            this.btn_port_disconnect.Text = "Rozłącz";
            this.btn_port_disconnect.UseVisualStyleBackColor = true;
            this.btn_port_disconnect.Click += new System.EventHandler(this.btn_port_disconnect_Click);
            // 
            // lab_port_connection
            // 
            this.lab_port_connection.AutoSize = true;
            this.lab_port_connection.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lab_port_connection.Location = new System.Drawing.Point(345, 216);
            this.lab_port_connection.Name = "lab_port_connection";
            this.lab_port_connection.Size = new System.Drawing.Size(250, 25);
            this.lab_port_connection.TabIndex = 14;
            this.lab_port_connection.Text = "POŁĄCZENIE Z MODEMEM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 398);
            this.Controls.Add(this.lab_port_connection);
            this.Controls.Add(this.btn_port_disconnect);
            this.Controls.Add(this.btn_port_connect);
            this.Controls.Add(this.lab_mode);
            this.Controls.Add(this.btn_commands);
            this.Controls.Add(this.btn_writing);
            this.Controls.Add(this.lab_receiver_number);
            this.Controls.Add(this.lab_chat);
            this.Controls.Add(this.btn_answer);
            this.Controls.Add(this.btn_hang);
            this.Controls.Add(this.btn_call);
            this.Controls.Add(this.txb_receiver_number);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.txb_command_line);
            this.Controls.Add(this.txb_terminal);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(664, 437);
            this.MinimumSize = new System.Drawing.Size(664, 437);
            this.Name = "Form1";
            this.Text = "Modemy - Grupa E";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txb_terminal;
        private TextBox txb_command_line;
        private Button btn_send;
        private TextBox txb_receiver_number;
        private Button btn_call;
        private Button btn_hang;
        private Button btn_answer;
        private Label lab_chat;
        private Label lab_receiver_number;
        private Button btn_writing;
        private Button btn_commands;
        private Label lab_mode;
        private Button btn_port_connect;
        private Button btn_port_disconnect;
        private Label lab_port_connection;
    }
}