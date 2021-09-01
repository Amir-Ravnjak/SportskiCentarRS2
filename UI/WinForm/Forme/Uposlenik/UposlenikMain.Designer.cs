
namespace SportskiCentarRS2.WinForm.Forme.Uposlenik
{
    partial class UposlenikMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UposlenikMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.terminiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rezervacijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prostorijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opremaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminiToolStripMenuItem,
            this.rezervacijeToolStripMenuItem,
            this.prostorijeToolStripMenuItem,
            this.opremaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // terminiToolStripMenuItem
            // 
            this.terminiToolStripMenuItem.Name = "terminiToolStripMenuItem";
            this.terminiToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.terminiToolStripMenuItem.Text = "Termini";
            this.terminiToolStripMenuItem.Click += new System.EventHandler(this.terminiToolStripMenuItem_Click);
            // 
            // rezervacijeToolStripMenuItem
            // 
            this.rezervacijeToolStripMenuItem.Name = "rezervacijeToolStripMenuItem";
            this.rezervacijeToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.rezervacijeToolStripMenuItem.Text = "Rezervacije";
            this.rezervacijeToolStripMenuItem.Click += new System.EventHandler(this.rezervacijeToolStripMenuItem_Click);
            // 
            // prostorijeToolStripMenuItem
            // 
            this.prostorijeToolStripMenuItem.Name = "prostorijeToolStripMenuItem";
            this.prostorijeToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.prostorijeToolStripMenuItem.Text = "Prostorije";
            this.prostorijeToolStripMenuItem.Click += new System.EventHandler(this.prostorijeToolStripMenuItem_Click);
            // 
            // opremaToolStripMenuItem
            // 
            this.opremaToolStripMenuItem.Name = "opremaToolStripMenuItem";
            this.opremaToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.opremaToolStripMenuItem.Text = "Oprema";
            this.opremaToolStripMenuItem.Click += new System.EventHandler(this.opremaToolStripMenuItem_Click);
            // 
            // UposlenikMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UposlenikMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sportski centar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UposlenikMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem terminiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rezervacijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prostorijeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opremaToolStripMenuItem;
    }
}