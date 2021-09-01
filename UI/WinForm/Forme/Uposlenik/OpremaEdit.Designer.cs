
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class OpremaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpremaEdit));
            this.btn_Snimi = new System.Windows.Forms.Button();
            this.btn_Otkazi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Naziv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_NaStanju = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_NaStanju)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Snimi
            // 
            this.btn_Snimi.Location = new System.Drawing.Point(204, 87);
            this.btn_Snimi.Name = "btn_Snimi";
            this.btn_Snimi.Size = new System.Drawing.Size(75, 23);
            this.btn_Snimi.TabIndex = 18;
            this.btn_Snimi.Text = "Snimi";
            this.btn_Snimi.UseVisualStyleBackColor = true;
            this.btn_Snimi.Click += new System.EventHandler(this.btn_Snimi_Click);
            // 
            // btn_Otkazi
            // 
            this.btn_Otkazi.Location = new System.Drawing.Point(14, 87);
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
            this.tb_Naziv.Location = new System.Drawing.Point(120, 5);
            this.tb_Naziv.Name = "tb_Naziv";
            this.tb_Naziv.Size = new System.Drawing.Size(159, 23);
            this.tb_Naziv.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Količina na stanju";
            // 
            // nud_NaStanju
            // 
            this.nud_NaStanju.Location = new System.Drawing.Point(120, 34);
            this.nud_NaStanju.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_NaStanju.Name = "nud_NaStanju";
            this.nud_NaStanju.Size = new System.Drawing.Size(159, 23);
            this.nud_NaStanju.TabIndex = 23;
            this.nud_NaStanju.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OpremaEdit
            // 
            this.AcceptButton = this.btn_Snimi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Otkazi;
            this.ClientSize = new System.Drawing.Size(293, 122);
            this.Controls.Add(this.nud_NaStanju);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_Naziv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Otkazi);
            this.Controls.Add(this.btn_Snimi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpremaEdit";
            this.ShowInTaskbar = false;
            this.Text = "Oprema";
            this.Load += new System.EventHandler(this.OpremaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_NaStanju)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Snimi;
        private System.Windows.Forms.Button btn_Otkazi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Naziv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_NaStanju;
    }
}