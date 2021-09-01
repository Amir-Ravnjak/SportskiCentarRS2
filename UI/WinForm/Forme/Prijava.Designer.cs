
namespace SportskiCentarRS2.WinForm.Forme
{
    partial class Prijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prijava));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_KorisnickoIme = new System.Windows.Forms.TextBox();
            this.tb_Lozinka = new System.Windows.Forms.TextBox();
            this.btn_Prijava = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(116, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sportski centar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(15, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Korisničko ime";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Lozinka";
            // 
            // tb_KorisnickoIme
            // 
            this.tb_KorisnickoIme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_KorisnickoIme.Location = new System.Drawing.Point(20, 94);
            this.tb_KorisnickoIme.Margin = new System.Windows.Forms.Padding(5);
            this.tb_KorisnickoIme.Name = "tb_KorisnickoIme";
            this.tb_KorisnickoIme.Size = new System.Drawing.Size(331, 21);
            this.tb_KorisnickoIme.TabIndex = 3;
            // 
            // tb_Lozinka
            // 
            this.tb_Lozinka.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_Lozinka.Location = new System.Drawing.Point(20, 154);
            this.tb_Lozinka.Margin = new System.Windows.Forms.Padding(5);
            this.tb_Lozinka.Name = "tb_Lozinka";
            this.tb_Lozinka.PasswordChar = '*';
            this.tb_Lozinka.Size = new System.Drawing.Size(331, 21);
            this.tb_Lozinka.TabIndex = 4;
            // 
            // btn_Prijava
            // 
            this.btn_Prijava.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_Prijava.Location = new System.Drawing.Point(260, 195);
            this.btn_Prijava.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Prijava.Name = "btn_Prijava";
            this.btn_Prijava.Size = new System.Drawing.Size(91, 28);
            this.btn_Prijava.TabIndex = 5;
            this.btn_Prijava.Text = "Prijava";
            this.btn_Prijava.UseVisualStyleBackColor = true;
            this.btn_Prijava.Click += new System.EventHandler(this.btn_Prijava_Click);
            // 
            // Prijava
            // 
            this.AcceptButton = this.btn_Prijava;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 237);
            this.Controls.Add(this.btn_Prijava);
            this.Controls.Add(this.tb_Lozinka);
            this.Controls.Add(this.tb_KorisnickoIme);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prijava";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prijava korisnika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_KorisnickoIme;
        private System.Windows.Forms.TextBox tb_Lozinka;
        private System.Windows.Forms.Button btn_Prijava;
    }
}

