namespace blutetooth
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_search = new System.Windows.Forms.Button();
            this.found_devices_display = new System.Windows.Forms.ListBox();
            this.btn_pair = new System.Windows.Forms.Button();
            this.btn_unpair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.files_to_send_display = new System.Windows.Forms.ListBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(12, 192);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(279, 37);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "Wyszukaj urządzenia";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // found_devices_display
            // 
            this.found_devices_display.FormattingEnabled = true;
            this.found_devices_display.ItemHeight = 20;
            this.found_devices_display.Location = new System.Drawing.Point(12, 45);
            this.found_devices_display.Name = "found_devices_display";
            this.found_devices_display.Size = new System.Drawing.Size(776, 144);
            this.found_devices_display.TabIndex = 2;
            // 
            // btn_pair
            // 
            this.btn_pair.Location = new System.Drawing.Point(297, 192);
            this.btn_pair.Name = "btn_pair";
            this.btn_pair.Size = new System.Drawing.Size(268, 37);
            this.btn_pair.TabIndex = 3;
            this.btn_pair.Text = "Sparuj";
            this.btn_pair.UseVisualStyleBackColor = true;
            this.btn_pair.Click += new System.EventHandler(this.btn_pair_Click);
            // 
            // btn_unpair
            // 
            this.btn_unpair.Location = new System.Drawing.Point(571, 192);
            this.btn_unpair.Name = "btn_unpair";
            this.btn_unpair.Size = new System.Drawing.Size(217, 37);
            this.btn_unpair.TabIndex = 4;
            this.btn_unpair.Text = "Rozłącz";
            this.btn_unpair.UseVisualStyleBackColor = true;
            this.btn_unpair.Click += new System.EventHandler(this.btn_unpair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wykryte urządzenia";
            // 
            // files_to_send_display
            // 
            this.files_to_send_display.FormattingEnabled = true;
            this.files_to_send_display.ItemHeight = 20;
            this.files_to_send_display.Location = new System.Drawing.Point(12, 235);
            this.files_to_send_display.Name = "files_to_send_display";
            this.files_to_send_display.Size = new System.Drawing.Size(776, 144);
            this.files_to_send_display.TabIndex = 6;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(223, 385);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(163, 40);
            this.btn_send.TabIndex = 7;
            this.btn_send.Text = "Wyślij plik";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(392, 385);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(164, 40);
            this.btn_upload.TabIndex = 8;
            this.btn_upload.Text = "Wczytaj plik";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.files_to_send_display);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_unpair);
            this.Controls.Add(this.btn_pair);
            this.Controls.Add(this.found_devices_display);
            this.Controls.Add(this.btn_search);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ListBox found_devices_display;
        private System.Windows.Forms.Button btn_pair;
        private System.Windows.Forms.Button btn_unpair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox files_to_send_display;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_upload;
    }
}

