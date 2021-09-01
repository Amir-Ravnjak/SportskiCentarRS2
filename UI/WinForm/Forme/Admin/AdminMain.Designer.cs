
namespace SportskiCentarRS2.WinForm.Forme.Admin
{
    partial class AdminMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmi_Korisnici = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Izvjestaji = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Korisnici,
            this.tsmi_Izvjestaji});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmi_Korisnici
            // 
            this.tsmi_Korisnici.Name = "tsmi_Korisnici";
            this.tsmi_Korisnici.Size = new System.Drawing.Size(64, 20);
            this.tsmi_Korisnici.Text = "Korisnici";
            this.tsmi_Korisnici.Click += new System.EventHandler(this.tsmi_Korisnici_Click);
            // 
            // tsmi_Izvjestaji
            // 
            this.tsmi_Izvjestaji.Name = "tsmi_Izvjestaji";
            this.tsmi_Izvjestaji.Size = new System.Drawing.Size(63, 20);
            this.tsmi_Izvjestaji.Text = "Izvještaji";
            this.tsmi_Izvjestaji.Click += new System.EventHandler(this.tsmi_Izvjestaji_Click);
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sportski centar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Korisnici;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Izvjestaji;
    }
}