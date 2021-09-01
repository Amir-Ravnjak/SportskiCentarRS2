
namespace SportskiCentarRS2.WinForm.Forme.Admin
{
    partial class Izvjestaji
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Klijent = new System.Windows.Forms.ComboBox();
            this.cb_Prostorija = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtp_DatumOd = new System.Windows.Forms.DateTimePicker();
            this.dtp_DatumDo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_Izvjestaj = new System.Windows.Forms.DataGridView();
            this.btn_Osvjezi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Izvjestaj)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Klijent";
            // 
            // cb_Klijent
            // 
            this.cb_Klijent.FormattingEnabled = true;
            this.cb_Klijent.Location = new System.Drawing.Point(101, 20);
            this.cb_Klijent.Name = "cb_Klijent";
            this.cb_Klijent.Size = new System.Drawing.Size(151, 23);
            this.cb_Klijent.TabIndex = 1;
            // 
            // cb_Prostorija
            // 
            this.cb_Prostorija.FormattingEnabled = true;
            this.cb_Prostorija.Location = new System.Drawing.Point(353, 20);
            this.cb_Prostorija.Name = "cb_Prostorija";
            this.cb_Prostorija.Size = new System.Drawing.Size(151, 23);
            this.cb_Prostorija.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prostorija";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Od";
            // 
            // dtp_DatumOd
            // 
            this.dtp_DatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DatumOd.Location = new System.Drawing.Point(563, 20);
            this.dtp_DatumOd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtp_DatumOd.Name = "dtp_DatumOd";
            this.dtp_DatumOd.Size = new System.Drawing.Size(154, 23);
            this.dtp_DatumOd.TabIndex = 5;
            this.dtp_DatumOd.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dtp_DatumDo
            // 
            this.dtp_DatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DatumDo.Location = new System.Drawing.Point(563, 49);
            this.dtp_DatumDo.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtp_DatumDo.Name = "dtp_DatumDo";
            this.dtp_DatumDo.Size = new System.Drawing.Size(154, 23);
            this.dtp_DatumDo.TabIndex = 7;
            this.dtp_DatumDo.Value = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(534, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Do";
            // 
            // dgv_Izvjestaj
            // 
            this.dgv_Izvjestaj.AllowUserToAddRows = false;
            this.dgv_Izvjestaj.AllowUserToDeleteRows = false;
            this.dgv_Izvjestaj.AllowUserToOrderColumns = true;
            this.dgv_Izvjestaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Izvjestaj.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Izvjestaj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Izvjestaj.Location = new System.Drawing.Point(26, 78);
            this.dgv_Izvjestaj.MultiSelect = false;
            this.dgv_Izvjestaj.Name = "dgv_Izvjestaj";
            this.dgv_Izvjestaj.ReadOnly = true;
            this.dgv_Izvjestaj.RowTemplate.Height = 25;
            this.dgv_Izvjestaj.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Izvjestaj.Size = new System.Drawing.Size(762, 311);
            this.dgv_Izvjestaj.TabIndex = 8;
            // 
            // btn_Osvjezi
            // 
            this.btn_Osvjezi.Location = new System.Drawing.Point(723, 49);
            this.btn_Osvjezi.Name = "btn_Osvjezi";
            this.btn_Osvjezi.Size = new System.Drawing.Size(75, 23);
            this.btn_Osvjezi.TabIndex = 9;
            this.btn_Osvjezi.Text = "Osvježi";
            this.btn_Osvjezi.UseVisualStyleBackColor = true;
            this.btn_Osvjezi.Click += new System.EventHandler(this.btn_Osvjezi_Click);
            // 
            // Izvjestaji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Osvjezi);
            this.Controls.Add(this.dgv_Izvjestaj);
            this.Controls.Add(this.dtp_DatumDo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtp_DatumOd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Prostorija);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Klijent);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Izvjestaji";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Izvjestaji";
            this.Load += new System.EventHandler(this.Izvjestaji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Izvjestaj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Klijent;
        private System.Windows.Forms.ComboBox cb_Prostorija;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_DatumOd;
        private System.Windows.Forms.DateTimePicker dtp_DatumDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_Izvjestaj;
        private System.Windows.Forms.Button btn_Osvjezi;
    }
}