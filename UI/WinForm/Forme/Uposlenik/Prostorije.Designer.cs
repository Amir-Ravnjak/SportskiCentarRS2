
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class Prostorije
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
            this.dgv_Prostorije = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Obrisi = new System.Windows.Forms.Button();
            this.btn_Izmijeni = new System.Windows.Forms.Button();
            this.btn_Kreiraj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Prostorije)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Prostorije
            // 
            this.dgv_Prostorije.AllowUserToAddRows = false;
            this.dgv_Prostorije.AllowUserToDeleteRows = false;
            this.dgv_Prostorije.AllowUserToOrderColumns = true;
            this.dgv_Prostorije.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Prostorije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Prostorije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Prostorije.Location = new System.Drawing.Point(12, 54);
            this.dgv_Prostorije.MultiSelect = false;
            this.dgv_Prostorije.Name = "dgv_Prostorije";
            this.dgv_Prostorije.ReadOnly = true;
            this.dgv_Prostorije.RowTemplate.Height = 25;
            this.dgv_Prostorije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Prostorije.Size = new System.Drawing.Size(776, 338);
            this.dgv_Prostorije.TabIndex = 1;
            this.dgv_Prostorije.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Prostorije_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Prostorije";
            // 
            // btn_Obrisi
            // 
            this.btn_Obrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Obrisi.Location = new System.Drawing.Point(428, 398);
            this.btn_Obrisi.Name = "btn_Obrisi";
            this.btn_Obrisi.Size = new System.Drawing.Size(75, 23);
            this.btn_Obrisi.TabIndex = 6;
            this.btn_Obrisi.Text = "Obriši";
            this.btn_Obrisi.UseVisualStyleBackColor = true;
            this.btn_Obrisi.Click += new System.EventHandler(this.btn_Obrisi_Click);
            // 
            // btn_Izmijeni
            // 
            this.btn_Izmijeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Izmijeni.Location = new System.Drawing.Point(509, 398);
            this.btn_Izmijeni.Name = "btn_Izmijeni";
            this.btn_Izmijeni.Size = new System.Drawing.Size(184, 23);
            this.btn_Izmijeni.TabIndex = 5;
            this.btn_Izmijeni.Text = "Izmijeni odabranu prostoriju";
            this.btn_Izmijeni.UseVisualStyleBackColor = true;
            this.btn_Izmijeni.Click += new System.EventHandler(this.btn_Izmijeni_Click);
            // 
            // btn_Kreiraj
            // 
            this.btn_Kreiraj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Kreiraj.Location = new System.Drawing.Point(699, 398);
            this.btn_Kreiraj.Name = "btn_Kreiraj";
            this.btn_Kreiraj.Size = new System.Drawing.Size(75, 23);
            this.btn_Kreiraj.TabIndex = 4;
            this.btn_Kreiraj.Text = "Kreiraj";
            this.btn_Kreiraj.UseVisualStyleBackColor = true;
            this.btn_Kreiraj.Click += new System.EventHandler(this.btn_Kreiraj_Click);
            // 
            // Prostorije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Obrisi);
            this.Controls.Add(this.btn_Izmijeni);
            this.Controls.Add(this.btn_Kreiraj);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Prostorije);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prostorije";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Prostorije";
            this.Load += new System.EventHandler(this.Prostorije_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Prostorije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Prostorije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Obrisi;
        private System.Windows.Forms.Button btn_Izmijeni;
        private System.Windows.Forms.Button btn_Kreiraj;
    }
}