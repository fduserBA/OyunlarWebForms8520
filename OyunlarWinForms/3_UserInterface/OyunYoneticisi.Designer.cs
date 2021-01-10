
namespace OyunlarWinForms._3_UserInterface
{
    partial class OyunYoneticisi
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.oyunlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uygulamadanÇıkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oyunlarToolStripMenuItem,
            this.uygulamadanÇıkToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // oyunlarToolStripMenuItem
            // 
            this.oyunlarToolStripMenuItem.Name = "oyunlarToolStripMenuItem";
            this.oyunlarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.oyunlarToolStripMenuItem.Text = "Oyunlar";
            this.oyunlarToolStripMenuItem.Click += new System.EventHandler(this.oyunlarToolStripMenuItem_Click);
            // 
            // uygulamadanÇıkToolStripMenuItem
            // 
            this.uygulamadanÇıkToolStripMenuItem.Name = "uygulamadanÇıkToolStripMenuItem";
            this.uygulamadanÇıkToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.uygulamadanÇıkToolStripMenuItem.Text = "Uygulamadan Çık";
            this.uygulamadanÇıkToolStripMenuItem.Click += new System.EventHandler(this.uygulamadanÇıkToolStripMenuItem_Click);
            // 
            // OyunYoneticisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OyunYoneticisi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oyun Yöneticisi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OyunYoneticisi_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem oyunlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uygulamadanÇıkToolStripMenuItem;
    }
}

