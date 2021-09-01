
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class RezervacijeDetalji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezervacijeDetalji));
            this.btn_Nazad = new System.Windows.Forms.Button();
            this.btn_Odobri = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Prostorija = new System.Windows.Forms.Label();
            this.lbl_Termin = new System.Windows.Forms.Label();
            this.lbl_Klijent = new System.Windows.Forms.Label();
            this.lbl_Cijena = new System.Windows.Forms.Label();
            this.cb_Uplaceno = new System.Windows.Forms.CheckBox();
            this.cb_Odobreno = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_Nazad
            // 
            this.btn_Nazad.Location = new System.Drawing.Point(169, 157);
            this.btn_Nazad.Name = "btn_Nazad";
            this.btn_Nazad.Size = new System.Drawing.Size(75, 23);
            this.btn_Nazad.TabIndex = 18;
            this.btn_Nazad.Text = "Nazad";
            this.btn_Nazad.UseVisualStyleBackColor = true;
            this.btn_Nazad.Click += new System.EventHandler(this.btn_Nazad_Click);
            // 
            // btn_Odobri
            // 
            this.btn_Odobri.Location = new System.Drawing.Point(16, 157);
            this.btn_Odobri.Name = "btn_Odobri";
            this.btn_Odobri.Size = new System.Drawing.Size(75, 23);
            this.btn_Odobri.TabIndex = 19;
            this.btn_Odobri.Text = "Odobri";
            this.btn_Odobri.UseVisualStyleBackColor = true;
            this.btn_Odobri.Click += new System.EventHandler(this.btn_Odobri_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Prostorija: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(16, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "Termin: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(16, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Klijent: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cijena: ";
            // 
            // lbl_Prostorija
            // 
            this.lbl_Prostorija.AutoSize = true;
            this.lbl_Prostorija.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Prostorija.Location = new System.Drawing.Point(87, 11);
            this.lbl_Prostorija.Name = "lbl_Prostorija";
            this.lbl_Prostorija.Size = new System.Drawing.Size(57, 15);
            this.lbl_Prostorija.TabIndex = 28;
            this.lbl_Prostorija.Text = "prostorija";
            // 
            // lbl_Termin
            // 
            this.lbl_Termin.AutoSize = true;
            this.lbl_Termin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Termin.Location = new System.Drawing.Point(87, 35);
            this.lbl_Termin.Name = "lbl_Termin";
            this.lbl_Termin.Size = new System.Drawing.Size(42, 15);
            this.lbl_Termin.TabIndex = 29;
            this.lbl_Termin.Text = "termin";
            // 
            // lbl_Klijent
            // 
            this.lbl_Klijent.AutoSize = true;
            this.lbl_Klijent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Klijent.Location = new System.Drawing.Point(87, 59);
            this.lbl_Klijent.Name = "lbl_Klijent";
            this.lbl_Klijent.Size = new System.Drawing.Size(39, 15);
            this.lbl_Klijent.TabIndex = 30;
            this.lbl_Klijent.Text = "klijent";
            // 
            // lbl_Cijena
            // 
            this.lbl_Cijena.AutoSize = true;
            this.lbl_Cijena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Cijena.Location = new System.Drawing.Point(87, 83);
            this.lbl_Cijena.Name = "lbl_Cijena";
            this.lbl_Cijena.Size = new System.Drawing.Size(38, 15);
            this.lbl_Cijena.TabIndex = 31;
            this.lbl_Cijena.Text = "cijena";
            // 
            // cb_Uplaceno
            // 
            this.cb_Uplaceno.AutoSize = true;
            this.cb_Uplaceno.Location = new System.Drawing.Point(86, 107);
            this.cb_Uplaceno.Name = "cb_Uplaceno";
            this.cb_Uplaceno.Size = new System.Drawing.Size(76, 19);
            this.cb_Uplaceno.TabIndex = 32;
            this.cb_Uplaceno.Text = "Uplaćeno";
            this.cb_Uplaceno.UseVisualStyleBackColor = true;
            // 
            // cb_Odobreno
            // 
            this.cb_Odobreno.AutoSize = true;
            this.cb_Odobreno.Location = new System.Drawing.Point(86, 123);
            this.cb_Odobreno.Name = "cb_Odobreno";
            this.cb_Odobreno.Size = new System.Drawing.Size(80, 19);
            this.cb_Odobreno.TabIndex = 33;
            this.cb_Odobreno.Text = "Odobreno";
            this.cb_Odobreno.UseVisualStyleBackColor = true;
            // 
            // RezervacijeDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 192);
            this.Controls.Add(this.cb_Odobreno);
            this.Controls.Add(this.cb_Uplaceno);
            this.Controls.Add(this.lbl_Cijena);
            this.Controls.Add(this.lbl_Klijent);
            this.Controls.Add(this.lbl_Termin);
            this.Controls.Add(this.lbl_Prostorija);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Odobri);
            this.Controls.Add(this.btn_Nazad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RezervacijeDetalji";
            this.ShowInTaskbar = false;
            this.Text = "Rezervacija";
            this.Load += new System.EventHandler(this.RezervacijeDetalji_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Nazad;
        private System.Windows.Forms.Button btn_Odobri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Prostorija;
        private System.Windows.Forms.Label lbl_Termin;
        private System.Windows.Forms.Label lbl_Klijent;
        private System.Windows.Forms.Label lbl_Cijena;
        private System.Windows.Forms.CheckBox cb_Uplaceno;
        private System.Windows.Forms.CheckBox cb_Odobreno;
    }
}