using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OyunlarWinForms._2_Business.Enums;
using OyunlarWinForms._2_Business.Models;
using OyunlarWinForms._2_Business.Services;

namespace OyunlarWinForms._3_UserInterface
{
    public partial class OyunEkle : Form
    {
        private readonly YilService yilService = new YilService();
        private readonly TurService turService = new TurService();
        private readonly OyunService oyunService = new OyunService();

        //public OyunEkle()
        //{
        //    InitializeComponent();
        //}

        private readonly Oyunlar _oyunlarForm;

        public OyunEkle(Oyunlar oyunlarForm)
        {
            InitializeComponent();
            _oyunlarForm = oyunlarForm;

            this.MdiParent = _oyunlarForm.MdiParent;
            this.WindowState = FormWindowState.Maximized;
            this.Show();
        }

        private void OyunEkle_Load(object sender, EventArgs e)
        {
            FillYillar();
            FillTurler();
        }

        private void FillTurler()
        {
            lbTurleri.Items.Clear();
            var turler = turService.GetList();
            if (turler == null)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lbTurleri.ValueMember = "Id";
            lbTurleri.DisplayMember = "Adi";
            lbTurleri.DataSource = turler;
            lbTurleri.ClearSelected();
        }

        private void FillYillar()
        {
            ddlYili.Items.Clear();
            var yillar = yilService.GetList();
            yillar.Insert(0, new YilModel()
            {
                Id = -1,
                Degeri = "-- Seçiniz --"
            });
            ddlYili.ValueMember = "Id";
            ddlYili.DisplayMember = "Degeri";
            ddlYili.DataSource = yillar;
            ddlYili.SelectedIndex = 0;
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {
            var model = new OyunModel();
            model.Adi = tbAdi.Text;
            model.Kazanci = null;
            if (!string.IsNullOrWhiteSpace(tbKazanci.Text))
            {
                model.Kazanci = Convert.ToDouble(tbKazanci.Text, new CultureInfo("tr"));
            }

            model.Maliyeti = null;
            if (!string.IsNullOrWhiteSpace(tbMaliyeti.Text))
            {
                model.Maliyeti = Convert.ToDouble(tbMaliyeti.Text, new CultureInfo("tr"));
            }

            model.YilId = Convert.ToInt32(ddlYili.SelectedValue);

            model.Turler = new List<TurModel>();
            TurModel tur;
            foreach (var selectedItem in lbTurleri.SelectedItems)
            {
                //tur = (TurModel)selectedItem;
                tur = selectedItem as TurModel;
                model.Turler.Add(tur);
            }

            Islem islem = oyunService.Add(model);
            if (islem == Islem.Hata)
            {
                MessageBox.Show("İşlem sırasında hata meydana geldi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (islem == Islem.BasarisizDegerBos)
            {
                MessageBox.Show("Formdaki * ile işaretlenmiş alanlar dolu olmalıdır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (islem == Islem.BasarisizKayitVar)
            {
                MessageBox.Show("Girdiğiniz ada sahip oyun kaydı bulunmaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // işlem başarılı
            {
                this.Close();
                _oyunlarForm.FillGrid();
            }
        }
    }
}
