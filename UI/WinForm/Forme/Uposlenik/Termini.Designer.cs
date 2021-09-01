
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class Termini
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
            this.btn_Obrisi = new System.Windows.Forms.Button();
            this.btn_Izmijeni = new System.Windows.Forms.Button();
            this.btn_Kreiraj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Termini = new System.Windows.Forms.DataGridView();
            this.nud_TrenutnaStranica = new System.Windows.Forms.NumericUpDown();
            this.btn_Sljedeca = new System.Windows.Forms.Button();
            this.btn_Prethodna = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Termini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TrenutnaStranica)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Obrisi
            // 
            this.btn_Obrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Obrisi.Location = new System.Drawing.Point(428, 406);
            this.btn_Obrisi.Name = "btn_Obrisi";
            this.btn_Obrisi.Size = new System.Drawing.Size(75, 23);
            this.btn_Obrisi.TabIndex = 16;
            this.btn_Obrisi.Text = "Obriši";
            this.btn_Obrisi.UseVisualStyleBackColor = true;
            this.btn_Obrisi.Click += new System.EventHandler(this.btn_Obrisi_Click);
            // 
            // btn_Izmijeni
            // 
            this.btn_Izmijeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Izmijeni.Location = new System.Drawing.Point(509, 406);
            this.btn_Izmijeni.Name = "btn_Izmijeni";
            this.btn_Izmijeni.Size = new System.Drawing.Size(184, 23);
            this.btn_Izmijeni.TabIndex = 15;
            this.btn_Izmijeni.Text = "Izmijeni odabrani termin";
            this.btn_Izmijeni.UseVisualStyleBackColor = true;
            this.btn_Izmijeni.Click += new System.EventHandler(this.btn_Izmijeni_Click);
            // 
            // btn_Kreiraj
            // 
            this.btn_Kreiraj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Kreiraj.Location = new System.Drawing.Point(699, 406);
            this.btn_Kreiraj.Name = "btn_Kreiraj";
            this.btn_Kreiraj.Size = new System.Drawing.Size(75, 23);
            this.btn_Kreiraj.TabIndex = 14;
            this.btn_Kreiraj.Text = "Kreiraj";
            this.btn_Kreiraj.UseVisualStyleBackColor = true;
            this.btn_Kreiraj.Click += new System.EventHandler(this.btn_Kreiraj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Termini";
            // 
            // dgv_Termini
            // 
            this.dgv_Termini.AllowUserToAddRows = false;
            this.dgv_Termini.AllowUserToDeleteRows = false;
            this.dgv_Termini.AllowUserToOrderColumns = true;
            this.dgv_Termini.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Termini.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Termini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Termini.Location = new System.Drawing.Point(12, 62);
            this.dgv_Termini.MultiSelect = false;
            this.dgv_Termini.Name = "dgv_Termini";
            this.dgv_Termini.ReadOnly = true;
            this.dgv_Termini.RowTemplate.Height = 25;
            this.dgv_Termini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Termini.Size = new System.Drawing.Size(776, 338);
            this.dgv_Termini.TabIndex = 12;
            this.dgv_Termini.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Termini_CellDoubleClick);
            // 
            // nud_TrenutnaStranica
            // 
            this.nud_TrenutnaStranica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nud_TrenutnaStranica.Location = new System.Drawing.Point(104, 414);
            this.nud_TrenutnaStranica.Name = "nud_TrenutnaStranica";
            this.nud_TrenutnaStranica.Size = new System.Drawing.Size(52, 23);
            this.nud_TrenutnaStranica.TabIndex = 17;
            this.nud_TrenutnaStranica.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_TrenutnaStranica.ValueChanged += new System.EventHandler(this.nud_TrenutnaStranica_ValueChanged);
            // 
            // btn_Sljedeca
            // 
            this.btn_Sljedeca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Sljedeca.Location = new System.Drawing.Point(162, 414);
            this.btn_Sljedeca.Name = "btn_Sljedeca";
            this.btn_Sljedeca.Size = new System.Drawing.Size(75, 23);
            this.btn_Sljedeca.TabIndex = 18;
            this.btn_Sljedeca.Text = "Sljedeća";
            this.btn_Sljedeca.UseVisualStyleBackColor = true;
            this.btn_Sljedeca.Click += new System.EventHandler(this.btn_Sljedeca_Click);
            // 
            // btn_Prethodna
            // 
            this.btn_Prethodna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Prethodna.Location = new System.Drawing.Point(23, 414);
            this.btn_Prethodna.Name = "btn_Prethodna";
            this.btn_Prethodna.Size = new System.Drawing.Size(75, 23);
            this.btn_Prethodna.TabIndex = 19;
            this.btn_Prethodna.Text = "Prethodna";
            this.btn_Prethodna.UseVisualStyleBackColor = true;
            this.btn_Prethodna.Click += new System.EventHandler(this.btn_Prethodna_Click);
            // 
            // Termini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Prethodna);
            this.Controls.Add(this.btn_Sljedeca);
            this.Controls.Add(this.nud_TrenutnaStranica);
            this.Controls.Add(this.btn_Obrisi);
            this.Controls.Add(this.btn_Izmijeni);
            this.Controls.Add(this.btn_Kreiraj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Termini);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Termini";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Termini";
            this.Load += new System.EventHandler(this.Termini_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Termini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TrenutnaStranica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Obrisi;
        private System.Windows.Forms.Button btn_Izmijeni;
        private System.Windows.Forms.Button btn_Kreiraj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Termini;
        private System.Windows.Forms.NumericUpDown nud_TrenutnaStranica;
        private System.Windows.Forms.Button btn_Sljedeca;
        private System.Windows.Forms.Button btn_Prethodna;
    }
}