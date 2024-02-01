namespace kodyEAN13
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
            this.picBarcode = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.kodKraju = new System.Windows.Forms.TextBox();
            this.kodProducenta = new System.Windows.Forms.TextBox();
            this.KodProduktu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // picBarcode
            // 
            this.picBarcode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picBarcode.Location = new System.Drawing.Point(12, 211);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(424, 227);
            this.picBarcode.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(424, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // kodKraju
            // 
            this.kodKraju.Location = new System.Drawing.Point(12, 21);
            this.kodKraju.Name = "kodKraju";
            this.kodKraju.Size = new System.Drawing.Size(100, 23);
            this.kodKraju.TabIndex = 3;
            // 
            // kodProducenta
            // 
            this.kodProducenta.Location = new System.Drawing.Point(12, 50);
            this.kodProducenta.Name = "kodProducenta";
            this.kodProducenta.Size = new System.Drawing.Size(100, 23);
            this.kodProducenta.TabIndex = 4;
            // 
            // KodProduktu
            // 
            this.KodProduktu.Location = new System.Drawing.Point(12, 79);
            this.KodProduktu.Name = "KodProduktu";
            this.KodProduktu.Size = new System.Drawing.Size(100, 23);
            this.KodProduktu.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 450);
            this.Controls.Add(this.KodProduktu);
            this.Controls.Add(this.kodProducenta);
            this.Controls.Add(this.kodKraju);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBarcode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel picBarcode;
        private Button button1;
        private TextBox kodKraju;
        private TextBox kodProducenta;
        private TextBox KodProduktu;
    }
}