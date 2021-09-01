
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class ProstorijeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProstorijeEdit));
            this.btn_Snimi = new System.Windows.Forms.Button();
            this.btn_Otkazi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Naziv = new System.Windows.Forms.TextBox();
            this.tb_Velicina = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pb_Slika = new System.Windows.Forms.PictureBox();
            this.btn_DodajSliku = new System.Windows.Forms.Button();
            this.ofd_Slika = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_UkloniSliku = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Slika)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Snimi
            // 
            this.btn_Snimi.Location = new System.Drawing.Point(204, 337);
            this.btn_Snimi.Name = "btn_Snimi";
            this.btn_Snimi.Size = new System.Drawing.Size(75, 23);
            this.btn_Snimi.TabIndex = 18;
            this.btn_Snimi.Text = "Snimi";
            this.btn_Snimi.UseVisualStyleBackColor = true;
            this.btn_Snimi.Click += new System.EventHandler(this.btn_Snimi_Click);
            // 
            // btn_Otkazi
            // 
            this.btn_Otkazi.Location = new System.Drawing.Point(14, 337);
            this.btn_Otkazi.Name = "btn_Otkazi";
            this.btn_Otkazi.Size = new System.Drawing.Size(75, 23);
            this.btn_Otkazi.TabIndex = 19;
            this.btn_Otkazi.Text = "Otkaži";
            this.btn_Otkazi.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Naziv";
            // 
            // tb_Naziv
            // 
            this.tb_Naziv.Location = new System.Drawing.Point(75, 5);
            this.tb_Naziv.Name = "tb_Naziv";
            this.tb_Naziv.Size = new System.Drawing.Size(204, 23);
            this.tb_Naziv.TabIndex = 21;
            // 
            // tb_Velicina
            // 
            this.tb_Velicina.Location = new System.Drawing.Point(75, 34);
            this.tb_Velicina.Name = "tb_Velicina";
            this.tb_Velicina.Size = new System.Drawing.Size(204, 23);
            this.tb_Velicina.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Veličina";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Slika";
            // 
            // pb_Slika
            // 
            this.pb_Slika.Location = new System.Drawing.Point(75, 71);
            this.pb_Slika.Name = "pb_Slika";
            this.pb_Slika.Size = new System.Drawing.Size(204, 114);
            this.pb_Slika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Slika.TabIndex = 25;
            this.pb_Slika.TabStop = false;
            // 
            // btn_DodajSliku
            // 
            this.btn_DodajSliku.Location = new System.Drawing.Point(13, 90);
            this.btn_DodajSliku.Name = "btn_DodajSliku";
            this.btn_DodajSliku.Size = new System.Drawing.Size(56, 23);
            this.btn_DodajSliku.TabIndex = 26;
            this.btn_DodajSliku.Text = "Odberi";
            this.btn_DodajSliku.UseVisualStyleBackColor = true;
            this.btn_DodajSliku.Click += new System.EventHandler(this.btn_DodajSliku_Click);
            // 
            // ofd_Slika
            // 
            this.ofd_Slika.DefaultExt = "jpg";
            this.ofd_Slika.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Oprema";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(75, 199);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 132);
            this.panel1.TabIndex = 28;
            // 
            // btn_UkloniSliku
            // 
            this.btn_UkloniSliku.Location = new System.Drawing.Point(14, 119);
            this.btn_UkloniSliku.Name = "btn_UkloniSliku";
            this.btn_UkloniSliku.Size = new System.Drawing.Size(55, 23);
            this.btn_UkloniSliku.TabIndex = 29;
            this.btn_UkloniSliku.Text = "Ukloni";
            this.btn_UkloniSliku.UseVisualStyleBackColor = true;
            this.btn_UkloniSliku.Click += new System.EventHandler(this.btn_UkloniSliku_Click);
            // 
            // ProstorijeEdit
            // 
            this.AcceptButton = this.btn_Snimi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Otkazi;
            this.ClientSize = new System.Drawing.Size(295, 372);
            this.Controls.Add(this.btn_UkloniSliku);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_DodajSliku);
            this.Controls.Add(this.pb_Slika);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Velicina);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Naziv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Otkazi);
            this.Controls.Add(this.btn_Snimi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProstorijeEdit";
            this.ShowInTaskbar = false;
            this.Text = "Prostorija";
            this.Load += new System.EventHandler(this.ProstorijeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Slika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Snimi;
        private System.Windows.Forms.Button btn_Otkazi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Naziv;
        private System.Windows.Forms.TextBox tb_Velicina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pb_Slika;
        private System.Windows.Forms.Button btn_DodajSliku;
        private System.Windows.Forms.OpenFileDialog ofd_Slika;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_UkloniSliku;
    }
}