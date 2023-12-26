namespace WindowsFormsApp9
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
            this.components = new System.ComponentModel.Container();
            this.latitude = new System.Windows.Forms.TextBox();
            this.longtitude = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openMapsButton = new System.Windows.Forms.Button();
            this.gps_timer = new System.Windows.Forms.Timer(this.components);
            this.amount_of_satelites = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // latitude
            // 
            this.latitude.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.latitude.Location = new System.Drawing.Point(202, 59);
            this.latitude.Name = "latitude";
            this.latitude.ReadOnly = true;
            this.latitude.Size = new System.Drawing.Size(337, 26);
            this.latitude.TabIndex = 0;
            // 
            // longtitude
            // 
            this.longtitude.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.longtitude.Location = new System.Drawing.Point(202, 100);
            this.longtitude.Name = "longtitude";
            this.longtitude.ReadOnly = true;
            this.longtitude.Size = new System.Drawing.Size(336, 26);
            this.longtitude.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Szerokość geograficzna:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Długość geograficzna:";
            // 
            // time
            // 
            this.time.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.time.Location = new System.Drawing.Point(202, 146);
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Size = new System.Drawing.Size(335, 26);
            this.time.TabIndex = 4;
            // 
            // date
            // 
            this.date.BackColor = System.Drawing.SystemColors.HighlightText;
            this.date.Location = new System.Drawing.Point(202, 188);
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Size = new System.Drawing.Size(335, 26);
            this.date.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Czas:";
            // 
            // openMapsButton
            // 
            this.openMapsButton.Location = new System.Drawing.Point(14, 277);
            this.openMapsButton.Name = "openMapsButton";
            this.openMapsButton.Size = new System.Drawing.Size(523, 40);
            this.openMapsButton.TabIndex = 8;
            this.openMapsButton.Text = "Uruchom google Maps";
            this.openMapsButton.UseVisualStyleBackColor = true;
            this.openMapsButton.Click += new System.EventHandler(this.openMapsButton_Click);
            // 
            // gps_timer
            // 
            this.gps_timer.Interval = 1000;
            this.gps_timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // amount_of_satelites
            // 
            this.amount_of_satelites.Location = new System.Drawing.Point(202, 229);
            this.amount_of_satelites.Name = "amount_of_satelites";
            this.amount_of_satelites.Size = new System.Drawing.Size(336, 26);
            this.amount_of_satelites.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Użyte satelity:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 339);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.amount_of_satelites);
            this.Controls.Add(this.openMapsButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.date);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.longtitude);
            this.Controls.Add(this.latitude);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox latitude;
        private System.Windows.Forms.TextBox longtitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox time;
        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button openMapsButton;
        private System.Windows.Forms.Timer gps_timer;
        private System.Windows.Forms.TextBox amount_of_satelites;
        private System.Windows.Forms.Label label5;
    }
}

