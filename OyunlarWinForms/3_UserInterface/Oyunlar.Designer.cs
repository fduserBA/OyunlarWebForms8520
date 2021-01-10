
namespace OyunlarWinForms._3_UserInterface
{
    partial class Oyunlar
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
            this.dgvOyunlar = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOyunlar)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOyunlar
            // 
            this.dgvOyunlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOyunlar.Location = new System.Drawing.Point(13, 13);
            this.dgvOyunlar.Name = "dgvOyunlar";
            this.dgvOyunlar.Size = new System.Drawing.Size(775, 387);
            this.dgvOyunlar.TabIndex = 0;
            // 
            // Oyunlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvOyunlar);
            this.Name = "Oyunlar";
            this.Text = "Oyunlar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOyunlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOyunlar;
    }
}