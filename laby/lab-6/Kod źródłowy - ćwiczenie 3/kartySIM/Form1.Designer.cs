namespace kartySIM
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
            this.readerList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.sendCommandButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.responseBoxHex = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.responseBoxAscii = new System.Windows.Forms.TextBox();
            this.commandList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // readerList
            // 
            this.readerList.FormattingEnabled = true;
            this.readerList.Location = new System.Drawing.Point(82, 9);
            this.readerList.Name = "readerList";
            this.readerList.Size = new System.Drawing.Size(519, 28);
            this.readerList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Czytnik:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(607, 6);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(181, 32);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Połącz z kartą";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Komenda";
            // 
            // sendCommandButton
            // 
            this.sendCommandButton.Location = new System.Drawing.Point(607, 49);
            this.sendCommandButton.Name = "sendCommandButton";
            this.sendCommandButton.Size = new System.Drawing.Size(181, 33);
            this.sendCommandButton.TabIndex = 5;
            this.sendCommandButton.Text = "Wyślij";
            this.sendCommandButton.UseVisualStyleBackColor = true;
            this.sendCommandButton.Click += new System.EventHandler(this.sendCommandButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Odpowiedź (hex)";
            // 
            // responseBoxHex
            // 
            this.responseBoxHex.Location = new System.Drawing.Point(17, 136);
            this.responseBoxHex.Name = "responseBoxHex";
            this.responseBoxHex.Size = new System.Drawing.Size(770, 26);
            this.responseBoxHex.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Odpowiedź (ASCII)";
            // 
            // responseBoxAscii
            // 
            this.responseBoxAscii.Location = new System.Drawing.Point(21, 224);
            this.responseBoxAscii.Name = "responseBoxAscii";
            this.responseBoxAscii.Size = new System.Drawing.Size(765, 26);
            this.responseBoxAscii.TabIndex = 9;
            // 
            // commandList
            // 
            this.commandList.FormattingEnabled = true;
            this.commandList.Items.AddRange(new object[] {
            "select file telecom",
            "select file mf",
            "select file adn",
            "get response",
            "read record"});
            this.commandList.Location = new System.Drawing.Point(96, 52);
            this.commandList.Name = "commandList";
            this.commandList.Size = new System.Drawing.Size(505, 28);
            this.commandList.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 784);
            this.Controls.Add(this.commandList);
            this.Controls.Add(this.responseBoxAscii);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.responseBoxHex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendCommandButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readerList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox readerList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendCommandButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox responseBoxHex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox responseBoxAscii;
        private System.Windows.Forms.ComboBox commandList;
    }
}

