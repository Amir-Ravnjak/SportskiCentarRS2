
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class Rezervacije
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
            this.btn_Prethodna = new System.Windows.Forms.Button();
            this.btn_Sljedeca = new System.Windows.Forms.Button();
            this.nud_TrenutnaStranica = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Rezervacije = new System.Windows.Forms.DataGridView();
            this.btn_Detalji = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_TrenutnaStranica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rezervacije)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Prethodna
            // 
            this.btn_Prethodna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Prethodna.Location = new System.Drawing.Point(23, 410);
            this.btn_Prethodna.Name = "btn_Prethodna";
            this.btn_Prethodna.Size = new System.Drawing.Size(75, 23);
            this.btn_Prethodna.TabIndex = 24;
            this.btn_Prethodna.Text = "Prethodna";
            this.btn_Prethodna.UseVisualStyleBackColor = true;
            this.btn_Prethodna.Click += new System.EventHandler(this.btn_Prethodna_Click);
            // 
            // btn_Sljedeca
            // 
            this.btn_Sljedeca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Sljedeca.Location = new System.Drawing.Point(162, 410);
            this.btn_Sljedeca.Name = "btn_Sljedeca";
            this.btn_Sljedeca.Size = new System.Drawing.Size(75, 23);
            this.btn_Sljedeca.TabIndex = 23;
            this.btn_Sljedeca.Text = "Sljedeća";
            this.btn_Sljedeca.UseVisualStyleBackColor = true;
            this.btn_Sljedeca.Click += new System.EventHandler(this.btn_Sljedeca_Click);
            // 
            // nud_TrenutnaStranica
            // 
            this.nud_TrenutnaStranica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nud_TrenutnaStranica.Location = new System.Drawing.Point(104, 410);
            this.nud_TrenutnaStranica.Name = "nud_TrenutnaStranica";
            this.nud_TrenutnaStranica.Size = new System.Drawing.Size(52, 23);
            this.nud_TrenutnaStranica.TabIndex = 22;
            this.nud_TrenutnaStranica.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_TrenutnaStranica.ValueChanged += new System.EventHandler(this.nud_TrenutnaStranica_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 21;
            this.label1.Text = "Rezervacije";
            // 
            // dgv_Rezervacije
            // 
            this.dgv_Rezervacije.AllowUserToAddRows = false;
            this.dgv_Rezervacije.AllowUserToDeleteRows = false;
            this.dgv_Rezervacije.AllowUserToOrderColumns = true;
            this.dgv_Rezervacije.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Rezervacije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Rezervacije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Rezervacije.Location = new System.Drawing.Point(12, 58);
            this.dgv_Rezervacije.MultiSelect = false;
            this.dgv_Rezervacije.Name = "dgv_Rezervacije";
            this.dgv_Rezervacije.ReadOnly = true;
            this.dgv_Rezervacije.RowTemplate.Height = 25;
            this.dgv_Rezervacije.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Rezervacije.Size = new System.Drawing.Size(776, 338);
            this.dgv_Rezervacije.TabIndex = 20;
            this.dgv_Rezervacije.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Rezervacije_CellDoubleClick);
            // 
            // btn_Detalji
            // 
            this.btn_Detalji.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Detalji.Location = new System.Drawing.Point(627, 409);
            this.btn_Detalji.Name = "btn_Detalji";
            this.btn_Detalji.Size = new System.Drawing.Size(160, 23);
            this.btn_Detalji.TabIndex = 25;
            this.btn_Detalji.Text = "Detalji odabrane rezervacije";
            this.btn_Detalji.UseVisualStyleBackColor = true;
            this.btn_Detalji.Click += new System.EventHandler(this.btn_Detalji_Click);
            // 
            // Rezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Detalji);
            this.Controls.Add(this.btn_Prethodna);
            this.Controls.Add(this.btn_Sljedeca);
            this.Controls.Add(this.nud_TrenutnaStranica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Rezervacije);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rezervacije";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Rezervacije";
            this.Load += new System.EventHandler(this.Rezervacije_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_TrenutnaStranica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Rezervacije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Prethodna;
        private System.Windows.Forms.Button btn_Sljedeca;
        private System.Windows.Forms.NumericUpDown nud_TrenutnaStranica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Rezervacije;
        private System.Windows.Forms.Button btn_Detalji;
    }
}