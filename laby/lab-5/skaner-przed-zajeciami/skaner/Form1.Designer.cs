namespace skaner
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resolutionField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fileTypeBox = new System.Windows.Forms.ComboBox();
            this.scanButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.filePathBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.rotationBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.scannerBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectPathButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.picturePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(621, 583);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ustawienia skanowania";
            // 
            // resolutionField
            // 
            this.resolutionField.Location = new System.Drawing.Point(109, 117);
            this.resolutionField.Name = "resolutionField";
            this.resolutionField.Size = new System.Drawing.Size(215, 23);
            this.resolutionField.TabIndex = 2;
            this.resolutionField.Text = "300";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "DPI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(330, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Podgląd";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Kolorystyka";
            // 
            // colorBox
            // 
            this.colorBox.FormattingEnabled = true;
            this.colorBox.Items.AddRange(new object[] {
            "czarno-biały",
            "kolorowy"});
            this.colorBox.Location = new System.Drawing.Point(109, 146);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(215, 23);
            this.colorBox.TabIndex = 7;
            this.colorBox.Text = "kolorowy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Typ pliku";
            // 
            // fileTypeBox
            // 
            this.fileTypeBox.FormattingEnabled = true;
            this.fileTypeBox.Items.AddRange(new object[] {
            "bmp",
            "png",
            "jpg"});
            this.fileTypeBox.Location = new System.Drawing.Point(109, 59);
            this.fileTypeBox.Name = "fileTypeBox";
            this.fileTypeBox.Size = new System.Drawing.Size(215, 23);
            this.fileTypeBox.TabIndex = 10;
            this.fileTypeBox.Text = "png";
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(86, 204);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(154, 23);
            this.scanButton.TabIndex = 11;
            this.scanButton.Text = "Skanuj";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(86, 233);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(154, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Zapisz do pliku";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // filePathBox
            // 
            this.filePathBox.Location = new System.Drawing.Point(109, 88);
            this.filePathBox.Name = "filePathBox";
            this.filePathBox.Size = new System.Drawing.Size(174, 23);
            this.filePathBox.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Ścieżka do pliku";
            // 
            // picturePanel
            // 
            this.picturePanel.AutoScroll = true;
            this.picturePanel.Controls.Add(this.picture);
            this.picturePanel.Location = new System.Drawing.Point(330, 30);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(621, 583);
            this.picturePanel.TabIndex = 15;
            // 
            // rotationBox
            // 
            this.rotationBox.FormattingEnabled = true;
            this.rotationBox.Items.AddRange(new object[] {
            "-270",
            "-180",
            "-90",
            "0",
            "90",
            "180",
            "270"});
            this.rotationBox.Location = new System.Drawing.Point(109, 175);
            this.rotationBox.Name = "rotationBox";
            this.rotationBox.Size = new System.Drawing.Size(215, 23);
            this.rotationBox.TabIndex = 17;
            this.rotationBox.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Obrót";
            // 
            // scannerBox
            // 
            this.scannerBox.FormattingEnabled = true;
            this.scannerBox.Location = new System.Drawing.Point(109, 30);
            this.scannerBox.Name = "scannerBox";
            this.scannerBox.Size = new System.Drawing.Size(215, 23);
            this.scannerBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Skaner";
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(289, 88);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(35, 23);
            this.selectPathButton.TabIndex = 20;
            this.selectPathButton.Text = "...";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 625);
            this.Controls.Add(this.selectPathButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.scannerBox);
            this.Controls.Add(this.rotationBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.filePathBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.fileTypeBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resolutionField);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "picture";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picture;
        private Label label1;
        private TextBox resolutionField;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox colorBox;
        private Label label5;
        private ComboBox fileTypeBox;
        private Button scanButton;
        private Button saveButton;
        private TextBox filePathBox;
        private Label label6;
        private Panel picturePanel;
        private ComboBox rotationBox;
        private Label label7;
        private ComboBox scannerBox;
        private Label label8;
        private Button selectPathButton;
    }
}