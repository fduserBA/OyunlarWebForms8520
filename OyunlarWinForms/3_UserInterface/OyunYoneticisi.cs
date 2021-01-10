using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class OyunYoneticisi : Form
    {
        public OyunYoneticisi()
        {
            InitializeComponent();
        }

        private void oyunlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Oyunlar oyunlarForm = new Oyunlar();
            //oyunlarForm.MdiParent = this;
            //oyunlarForm.WindowState = FormWindowState.Maximized;
            //oyunlarForm.Show();

            Oyunlar oyunlarForm = new Oyunlar(this);
        }

        private void OyunYoneticisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void uygulamadanÇıkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
