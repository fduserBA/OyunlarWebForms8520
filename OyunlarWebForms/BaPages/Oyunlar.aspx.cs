﻿using OyunlarWebForms.BaEntities;
using OyunlarWebForms.BaModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class Oyunlar : System.Web.UI.Page
    {
        private OyunlarContext db = new OyunlarContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // sayfanın ilk getirilme işlemi
            {
                FillGrid();
            }

            pDetay.Visible = false;
            pYeni.Visible = false;
        }

        private void FillGrid()
        {
            // lazy loading
            //List<Oyun> oyunlarEntity = db.Oyun.ToList();
            // eager loading
            List<Oyun> oyunlarEntity = db.Oyun.Include("Yil").ToList();

            List<OyunModel> oyunlarModel = new List<OyunModel>();
            OyunModel oyunModel;

            //foreach (Oyun oyunEntity in oyunlarEntity)
            //{
            //    oyunModel = new OyunModel()
            //    {
            //        Id = oyunEntity.Id,
            //        Adi = oyunEntity.Adi,
            //        Kazanci = oyunEntity.Kazanci,
            //        Maliyeti = oyunEntity.Maliyeti,
            //        YilId = oyunEntity.YilId,
            //        YilDegeri = oyunEntity.Yil.Degeri
            //    };
            //    oyunlarModel.Add(oyunModel);
            //}
            // LINQ: Language Integrated Query
            oyunlarModel = oyunlarEntity.Select(oyunEntity => new OyunModel()
            {
                Id = oyunEntity.Id,
                Adi = oyunEntity.Adi,
                Kazanci = oyunEntity.Kazanci,
                Maliyeti = oyunEntity.Maliyeti,
                YilId = oyunEntity.YilId,
                YilDegeri = oyunEntity.Yil.Degeri,
                //KarZarar = oyunEntity.Kazanci != null && oyunEntity.Maliyeti.HasValue ? (oyunEntity.Kazanci.Value - oyunEntity.Maliyeti.Value).ToString(CultureInfo.InvariantCulture).Replace(".", ",") : ""
                KarZarar = oyunEntity.Kazanci.HasValue && oyunEntity.Maliyeti.HasValue ? (oyunEntity.Kazanci.Value - oyunEntity.Maliyeti.Value).ToString("C2", new CultureInfo("tr")) : ""
            }).ToList();
            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings?redirectedfrom=MSDN

            gvOyunlar.DataSource = oyunlarModel;
            gvOyunlar.DataBind();

            gvOyunlar.HeaderRow.Cells[1].Visible = false; // Id
            foreach (GridViewRow row in gvOyunlar.Rows)
            {
                row.Cells[1].Visible = false; // Id
            }

            // CRUD: Create, Read, Update, Delete
        }

        protected void bDetay_Click(object sender, EventArgs e)
        {
            lBilgi.Text = "";
            if (gvOyunlar.SelectedIndex == -1)
            {
                lBilgi.Text = "Lütfen listeden kayıt seçiniz...";
                return;
            }

            int id = Convert.ToInt32(gvOyunlar.SelectedRow.Cells[1].Text);

            //lBilgi.Text = id;

            Oyun oyunEntity;

            // Sonu OrDefault ile biten LINQ methodları eğer kayıt bulunamazsa null döner. Default ile bitmeyenler kayıt bulunamazsa hata fırlatır.
            // Where(koşul(lar)) belirtilen koşul(lar)a uygun içerisinde kayıt olmayan, tek kayıt olan veya birden çok kayıt olan bir veri kümesi döner.
            // Bu küme içerisinden ihtiyaç duyulan kayda SingleOrDefault() veya FirstOrDefault() ile ulaşılabilir.
            //oyunEntity = db.Oyun.Where(oyun => oyun.Id == id).SingleOrDefault(); // Filtreleme sonucundan tek kayıt getir, birden çok kayıt gelirse hata verir.
            //oyunEntity = db.Oyun.Where(oyun => oyun.Id == id).FirstOrDefault(); // Filtreleme sonucundan ilk kaydı getir.

            // LastOrDefault() methodu bazı durumlarda hata verebilir. Eğer mutlaka kullanılması gerekiyorsa bu tip durumlarda bir aşağıdaki comment'siz
            // satırda olduğu gibi kayıtlar belli koşul(lar)a göre azalan olarak sıralanıp ilk kayıt çekilerek son kayda ulaşılmış olur.
            //oyunEntity = db.Oyun.Where(oyun => oyun.Id == id).LastOrDefault(); // Filtreleme sonucundan son kaydı getir.
            //oyunEntity = db.Oyun.OrderByDescending(oyun => oyun.Id).Where(oyun => oyun.Id == id).FirstOrDefault(); // Filtreleme sonucundan son kaydı getir.



            // Aşağıdaki methodlar belirtilen koşul(lar)a uygun tek bir kayıt döner.
            // Eğer belirtilen koşul(lar)a göre tek bir kayda ulaşılmak isteniyorsa aşağıdaki methodları kullanmak daha doğrudur.
            //oyunEntity = db.Oyun.FirstOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan ilk kaydı getir.

            // LastOrDefault(koşul(lar)) methodu bazı durumlarda hata verebilir. Eğer mutlaka kullanılması gerekiyorsa bu tip durumlarda bir aşağıdaki comment'siz
            // satırda olduğu gibi kayıtlar belli koşul(lar)a göre azalan olarak sıralanıp ilk kayıt çekilerek son kayda ulaşılmış olur.
            //oyunEntity = db.Oyun.LastOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan son kaydı getir.
            //oyunEntity = db.Oyun.OrderByDescending(oyun => oyun.Id).FirstOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan son kaydı getir.

            //oyunEntity = db.Oyun.SingleOrDefault(oyun => oyun.Id == id); // Filtreleme sonucundan tek kayıt getir, birden çok kayıt gelirse hata verir.

            // Yukarıdaki tüm LINQ methodları List gibi kolleksiyonlarda da kullanılabilir ancak aşğıdaki Find methodu sadece DbSet (Entity Framework) için kullanılabilir.
            oyunEntity = db.Oyun.Find(id);

            OyunModel oyunModel = new OyunModel();
            oyunModel.Id = oyunEntity.Id;
            oyunModel.Adi = oyunEntity.Adi;
            oyunModel.Kazanci = oyunEntity.Kazanci;
            oyunModel.Maliyeti = oyunEntity.Maliyeti;
            oyunModel.YilId = oyunEntity.YilId;
            oyunModel.YilDegeri = oyunEntity.Yil.Degeri;
            lAdi.Text = oyunModel.Adi;
            lMaliyeti.Text = "";
            if (oyunModel.Maliyeti.HasValue) // if (oyunModel.Maliyeti != null)
            {
                lMaliyeti.Text = oyunModel.Maliyeti.Value.ToString(new CultureInfo("tr"));
            }
            lKazanci.Text = "";
            if (oyunModel.Kazanci != null) // if (oyunModel.Kazanci.HasValue)
            {
                lKazanci.Text = oyunModel.Kazanci.Value.ToString(new CultureInfo("tr"));
            }
            lYili.Text = oyunModel.YilDegeri;
            pDetay.Visible = true;
        }

        protected void lbYeni_Click(object sender, EventArgs e)
        {
            FillYillar();
            //pYeni.Visible = !pYeni.Visible;
            pYeni.Visible = true;
        }

        private void FillYillar()
        {
            ddlYili.Items.Clear();
            //var yillarEntity = db.Yil.ToList().OrderByDescending(yil => yil.Degeri).ToList();
            var yillarEntity = db.Yil.OrderByDescending(yil => yil.Degeri).ToList();
            var yillarModel = yillarEntity.Select(yilEntity => new YilModel()
            {
                Id = yilEntity.Id,
                Degeri = yilEntity.Degeri
            }).ToList();
            ddlYili.DataValueField = "Id";
            ddlYili.DataTextField = "Degeri";
            ddlYili.DataSource = yillarModel;
            ddlYili.DataBind();
            ddlYili.Items.Insert(0, "-- Seçiniz --");
        }

        protected void bKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbAdi.Text))
            {
                lBilgi.Text = "Adı boş bırakılamaz!";
                return;
            }

            double maliyetValidasyon;
            double kazanciValidasyon;
            if (!string.IsNullOrWhiteSpace(tbMaliyeti.Text))
            {
                if (!double.TryParse(tbMaliyeti.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out maliyetValidasyon))
                {
                    lBilgi.Text = "Maliyet sayısal olmalıdır!";
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(tbKazanci.Text))
            {
                if (!double.TryParse(tbKazanci.Text.Trim().Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out kazanciValidasyon))
                {
                    lBilgi.Text = "Kazancı sayısal olmalıdır!";
                    return;
                }
            }

            if (ddlYili.SelectedIndex == 0) // -- Seçiniz --
            {
                lBilgi.Text = "Yıl seçiniz";
                return;
            }

            OyunModel oyunModel = new OyunModel()
            {
                Adi = tbAdi.Text.Trim(),
                YilId = Convert.ToInt32(ddlYili.SelectedValue)
            };

            // 1,2: Türkçe
            // 1.2: İngilizce
            // 1.2: C# double verisi

            oyunModel.Maliyeti = null;
            if (!string.IsNullOrWhiteSpace(tbMaliyeti.Text))
            {
                oyunModel.Maliyeti = Convert.ToDouble(tbMaliyeti.Text.Trim().Replace(",", "."), CultureInfo.InvariantCulture);
            }

            oyunModel.Kazanci = null;
            if (!string.IsNullOrWhiteSpace(tbKazanci.Text))
            {
                oyunModel.Kazanci =
                    Convert.ToDouble(tbKazanci.Text.Trim().Replace(",", "."), CultureInfo.InvariantCulture);
            }

            Oyun oyunEntity = new Oyun()
            {
                Adi = oyunModel.Adi,
                Kazanci = oyunModel.Kazanci,
                Maliyeti = oyunModel.Maliyeti,
                YilId = oyunModel.YilId
            };

            db.Oyun.Add(oyunEntity);
            db.SaveChanges();
            lBilgi.Text = "Oyun başarıyla kaydedildi.";
            FillGrid();
        }

        protected void bTemizle_Click(object sender, EventArgs e)
        {
            tbAdi.Text = "";
            tbMaliyeti.Text = String.Empty;
            tbKazanci.Text = "";
            ddlYili.SelectedIndex = 0;
            lBilgi.Text = "";
            pYeni.Visible = true;
        }
    }
}