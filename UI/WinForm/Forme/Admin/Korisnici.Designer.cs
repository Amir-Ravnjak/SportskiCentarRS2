
namespace SportskiCentarRS2.WinForm.Forme.Admin
{
    partial class Korisnici
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
            this.tabmenu_Korisnici = new System.Windows.Forms.TabControl();
            this.tab_Administratori = new System.Windows.Forms.TabPage();
            this.dgv_Administratori = new System.Windows.Forms.DataGridView();
            this.tab_Uposlenici = new System.Windows.Forms.TabPage();
            this.dgv_Uposlenici = new System.Windows.Forms.DataGridView();
            this.tab_Klijenti = new System.Windows.Forms.TabPage();
            this.dgv_Klijenti = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Izmijeni = new System.Windows.Forms.Button();
            this.btn_Obrisi = new System.Windows.Forms.Button();
            this.tabmenu_Korisnici.SuspendLayout();
            this.tab_Administratori.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Administratori)).BeginInit();
            this.tab_Uposlenici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Uposlenici)).BeginInit();
            this.tab_Klijenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Klijenti)).BeginInit();
            this.SuspendLayout();
            // 
            // tabmenu_Korisnici
            // 
            this.tabmenu_Korisnici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabmenu_Korisnici.Controls.Add(this.tab_Administratori);
            this.tabmenu_Korisnici.Controls.Add(this.tab_Uposlenici);
            this.tabmenu_Korisnici.Controls.Add(this.tab_Klijenti);
            this.tabmenu_Korisnici.Location = new System.Drawing.Point(12, 12);
            this.tabmenu_Korisnici.Name = "tabmenu_Korisnici";
            this.tabmenu_Korisnici.SelectedIndex = 0;
            this.tabmenu_Korisnici.Size = new System.Drawing.Size(776, 372);
            this.tabmenu_Korisnici.TabIndex = 0;
            // 
            // tab_Administratori
            // 
            this.tab_Administratori.Controls.Add(this.dgv_Administratori);
            this.tab_Administratori.Location = new System.Drawing.Point(4, 24);
            this.tab_Administratori.Name = "tab_Administratori";
            this.tab_Administratori.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Administratori.Size = new System.Drawing.Size(768, 344);
            this.tab_Administratori.TabIndex = 0;
            this.tab_Administratori.Text = "Administratori";
            this.tab_Administratori.UseVisualStyleBackColor = true;
            // 
            // dgv_Administratori
            // 
            this.dgv_Administratori.AllowUserToAddRows = false;
            this.dgv_Administratori.AllowUserToDeleteRows = false;
            this.dgv_Administratori.AllowUserToOrderColumns = true;
            this.dgv_Administratori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Administratori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Administratori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Administratori.Location = new System.Drawing.Point(3, 3);
            this.dgv_Administratori.MultiSelect = false;
            this.dgv_Administratori.Name = "dgv_Administratori";
            this.dgv_Administratori.ReadOnly = true;
            this.dgv_Administratori.RowTemplate.Height = 25;
            this.dgv_Administratori.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Administratori.Size = new System.Drawing.Size(762, 338);
            this.dgv_Administratori.TabIndex = 0;
            this.dgv_Administratori.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Administratori_CellDoubleClick);
            this.dgv_Administratori.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_Administratori_ColumnHeaderMouseDoubleClick);
            // 
            // tab_Uposlenici
            // 
            this.tab_Uposlenici.Controls.Add(this.dgv_Uposlenici);
            this.tab_Uposlenici.Location = new System.Drawing.Point(4, 24);
            this.tab_Uposlenici.Name = "tab_Uposlenici";
            this.tab_Uposlenici.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Uposlenici.Size = new System.Drawing.Size(768, 344);
            this.tab_Uposlenici.TabIndex = 1;
            this.tab_Uposlenici.Text = "Uposlenici";
            this.tab_Uposlenici.UseVisualStyleBackColor = true;
            // 
            // dgv_Uposlenici
            // 
            this.dgv_Uposlenici.AllowUserToAddRows = false;
            this.dgv_Uposlenici.AllowUserToDeleteRows = false;
            this.dgv_Uposlenici.AllowUserToOrderColumns = true;
            this.dgv_Uposlenici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Uposlenici.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Uposlenici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Uposlenici.Location = new System.Drawing.Point(3, 3);
            this.dgv_Uposlenici.MultiSelect = false;
            this.dgv_Uposlenici.Name = "dgv_Uposlenici";
            this.dgv_Uposlenici.ReadOnly = true;
            this.dgv_Uposlenici.RowTemplate.Height = 25;
            this.dgv_Uposlenici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Uposlenici.Size = new System.Drawing.Size(762, 338);
            this.dgv_Uposlenici.TabIndex = 1;
            this.dgv_Uposlenici.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Uposlenici_CellDoubleClick);
            // 
            // tab_Klijenti
            // 
            this.tab_Klijenti.Controls.Add(this.dgv_Klijenti);
            this.tab_Klijenti.Location = new System.Drawing.Point(4, 24);
            this.tab_Klijenti.Name = "tab_Klijenti";
            this.tab_Klijenti.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Klijenti.Size = new System.Drawing.Size(768, 344);
            this.tab_Klijenti.TabIndex = 2;
            this.tab_Klijenti.Text = "Klijenti";
            this.tab_Klijenti.UseVisualStyleBackColor = true;
            // 
            // dgv_Klijenti
            // 
            this.dgv_Klijenti.AllowUserToAddRows = false;
            this.dgv_Klijenti.AllowUserToDeleteRows = false;
            this.dgv_Klijenti.AllowUserToOrderColumns = true;
            this.dgv_Klijenti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Klijenti.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Klijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Klijenti.Location = new System.Drawing.Point(3, 3);
            this.dgv_Klijenti.MultiSelect = false;
            this.dgv_Klijenti.Name = "dgv_Klijenti";
            this.dgv_Klijenti.ReadOnly = true;
            this.dgv_Klijenti.RowTemplate.Height = 25;
            this.dgv_Klijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Klijenti.Size = new System.Drawing.Size(762, 338);
            this.dgv_Klijenti.TabIndex = 1;
            this.dgv_Klijenti.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Klijenti_CellDoubleClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(668, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Kreiraj novi nalog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Izmijeni
            // 
            this.btn_Izmijeni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Izmijeni.Location = new System.Drawing.Point(515, 391);
            this.btn_Izmijeni.Name = "btn_Izmijeni";
            this.btn_Izmijeni.Size = new System.Drawing.Size(147, 23);
            this.btn_Izmijeni.TabIndex = 2;
            this.btn_Izmijeni.Text = "Izmijeni odabrani nalog";
            this.btn_Izmijeni.UseVisualStyleBackColor = true;
            this.btn_Izmijeni.Click += new System.EventHandler(this.btn_Izmijeni_Click);
            // 
            // btn_Obrisi
            // 
            this.btn_Obrisi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Obrisi.Location = new System.Drawing.Point(434, 391);
            this.btn_Obrisi.Name = "btn_Obrisi";
            this.btn_Obrisi.Size = new System.Drawing.Size(75, 23);
            this.btn_Obrisi.TabIndex = 3;
            this.btn_Obrisi.Text = "Obriši";
            this.btn_Obrisi.UseVisualStyleBackColor = true;
            this.btn_Obrisi.Click += new System.EventHandler(this.btn_Obrisi_Click);
            // 
            // Korisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Obrisi);
            this.Controls.Add(this.btn_Izmijeni);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabmenu_Korisnici);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Korisnici";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Korisnici";
            this.Load += new System.EventHandler(this.Korisnici_Load);
            this.tabmenu_Korisnici.ResumeLayout(false);
            this.tab_Administratori.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Administratori)).EndInit();
            this.tab_Uposlenici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Uposlenici)).EndInit();
            this.tab_Klijenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Klijenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabmenu_Korisnici;
        private System.Windows.Forms.TabPage tab_Administratori;
        private System.Windows.Forms.TabPage tab_Uposlenici;
        private System.Windows.Forms.TabPage tab_Klijenti;
        private System.Windows.Forms.DataGridView dgv_Administratori;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_Uposlenici;
        private System.Windows.Forms.DataGridView dgv_Klijenti;
        private System.Windows.Forms.Button btn_Izmijeni;
        private System.Windows.Forms.Button btn_Obrisi;
    }
}