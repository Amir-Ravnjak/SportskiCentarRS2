
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class TerminiEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminiEdit));
            this.btn_Snimi = new System.Windows.Forms.Button();
            this.btn_Otkazi = new System.Windows.Forms.Button();
            this.cb_Prostorija = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtp_Datum = new System.Windows.Forms.DateTimePicker();
            this.dtp_Pocetak = new System.Windows.Forms.DateTimePicker();
            this.dtp_Kraj = new System.Windows.Forms.DateTimePicker();
            this.nud_Cijena = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Cijena)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Snimi
            // 
            this.btn_Snimi.Location = new System.Drawing.Point(206, 157);
            this.btn_Snimi.Name = "btn_Snimi";
            this.btn_Snimi.Size = new System.Drawing.Size(75, 23);
            this.btn_Snimi.TabIndex = 18;
            this.btn_Snimi.Text = "Snimi";
            this.btn_Snimi.UseVisualStyleBackColor = true;
            this.btn_Snimi.Click += new System.EventHandler(this.btn_Snimi_Click);
            // 
            // btn_Otkazi
            // 
            this.btn_Otkazi.Location = new System.Drawing.Point(16, 157);
            this.btn_Otkazi.Name = "btn_Otkazi";
            this.btn_Otkazi.Size = new System.Drawing.Size(75, 23);
            this.btn_Otkazi.TabIndex = 19;
            this.btn_Otkazi.Text = "Otkaži";
            this.btn_Otkazi.UseVisualStyleBackColor = true;
            // 
            // cb_Prostorija
            // 
            this.cb_Prostorija.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Prostorija.FormattingEnabled = true;
            this.cb_Prostorija.Location = new System.Drawing.Point(122, 12);
            this.cb_Prostorija.Name = "cb_Prostorija";
            this.cb_Prostorija.Size = new System.Drawing.Size(159, 23);
            this.cb_Prostorija.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "Prostorija";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 24;
            this.label1.Text = "Datum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 26;
            this.label2.Text = "Pocetak";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 15);
            this.label3.TabIndex = 28;
            this.label3.Text = "Kraj";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Cijena";
            // 
            // dtp_Datum
            // 
            this.dtp_Datum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Datum.Location = new System.Drawing.Point(122, 40);
            this.dtp_Datum.MinDate = new System.DateTime(2021, 8, 17, 0, 0, 0, 0);
            this.dtp_Datum.Name = "dtp_Datum";
            this.dtp_Datum.Size = new System.Drawing.Size(159, 23);
            this.dtp_Datum.TabIndex = 31;
            // 
            // dtp_Pocetak
            // 
            this.dtp_Pocetak.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_Pocetak.Location = new System.Drawing.Point(122, 69);
            this.dtp_Pocetak.MinDate = new System.DateTime(2021, 8, 17, 0, 0, 0, 0);
            this.dtp_Pocetak.Name = "dtp_Pocetak";
            this.dtp_Pocetak.ShowUpDown = true;
            this.dtp_Pocetak.Size = new System.Drawing.Size(159, 23);
            this.dtp_Pocetak.TabIndex = 32;
            this.dtp_Pocetak.Leave += new System.EventHandler(this.dtp_Pocetak_Leave);
            // 
            // dtp_Kraj
            // 
            this.dtp_Kraj.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_Kraj.Location = new System.Drawing.Point(122, 99);
            this.dtp_Kraj.MinDate = new System.DateTime(2021, 8, 17, 0, 0, 0, 0);
            this.dtp_Kraj.Name = "dtp_Kraj";
            this.dtp_Kraj.ShowUpDown = true;
            this.dtp_Kraj.Size = new System.Drawing.Size(159, 23);
            this.dtp_Kraj.TabIndex = 33;
            this.dtp_Kraj.Leave += new System.EventHandler(this.dtp_Kraj_Leave);
            // 
            // nud_Cijena
            // 
            this.nud_Cijena.Location = new System.Drawing.Point(122, 128);
            this.nud_Cijena.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_Cijena.Name = "nud_Cijena";
            this.nud_Cijena.Size = new System.Drawing.Size(159, 23);
            this.nud_Cijena.TabIndex = 34;
            // 
            // TerminiEdit
            // 
            this.AcceptButton = this.btn_Snimi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Otkazi;
            this.ClientSize = new System.Drawing.Size(293, 192);
            this.Controls.Add(this.nud_Cijena);
            this.Controls.Add(this.dtp_Kraj);
            this.Controls.Add(this.dtp_Pocetak);
            this.Controls.Add(this.dtp_Datum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Prostorija);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_Otkazi);
            this.Controls.Add(this.btn_Snimi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TerminiEdit";
            this.ShowInTaskbar = false;
            this.Text = "Termin";
            this.Load += new System.EventHandler(this.TerminiEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_Cijena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Snimi;
        private System.Windows.Forms.Button btn_Otkazi;
        private System.Windows.Forms.ComboBox cb_Prostorija;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtp_Datum;
        private System.Windows.Forms.DateTimePicker dtp_Pocetak;
        private System.Windows.Forms.DateTimePicker dtp_Kraj;
        private System.Windows.Forms.NumericUpDown nud_Cijena;
    }
}