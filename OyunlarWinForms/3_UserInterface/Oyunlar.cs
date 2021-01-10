using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OyunlarWinForms._2_Business.Services;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class Oyunlar : Form
    {
        private OyunService oyunService = new OyunService();

        //public Oyunlar()
        //{
        //    InitializeComponent();
        //}

        private readonly OyunYoneticisi _oyunYoneticisiForm;

        public Oyunlar(OyunYoneticisi oyunYoneticisiForm)
        {
            InitializeComponent();
            _oyunYoneticisiForm = oyunYoneticisiForm;
            this.MdiParent = _oyunYoneticisiForm;
            this.WindowState = FormWindowState.Maximized;
            this.Show();
        }

        private void Oyunlar_Load(object sender, EventArgs e)
        {
            //FillGrid();
        }

        private void Oyunlar_Shown(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()
        {
            var oyunlar = oyunService.GetList();
            dgvOyunlar.DataSource = oyunlar;
            dgvOyunlar.ClearSelection();
            SetColumnVisibilities();
            //SetColumnNames();
            SetColumnWidths();
        }

        private void SetColumnWidths()
        {
            //dgvOyunlar.Columns["KarZarar"].Width = 150;
            foreach (DataGridViewColumn column in dgvOyunlar.Columns)
            {
                column.Width = 150;
            }
        }

        private void SetColumnNames()
        {
            dgvOyunlar.Columns["Adi"].HeaderText = "Oyun Adı";
            dgvOyunlar.Columns["Kazanci"].HeaderText = "Oyun Kazancı";
            dgvOyunlar.Columns["Maliyeti"].HeaderText = "Oyun Maliyeti";
            dgvOyunlar.Columns["YilId"].HeaderText = "Oyun Yılı";
            dgvOyunlar.Columns["KarZarar"].HeaderText = "Oyun Karı / Zararı";
        }

        private void SetColumnVisibilities()
        {
            dgvOyunlar.Columns["Id"].Visible = false;
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OyunEkle form = new OyunEkle();
            //form.Show();

            OyunEkle form = new OyunEkle(this);
        }
    }
}
