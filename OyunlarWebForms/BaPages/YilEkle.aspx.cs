using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OyunlarWebForms.BaBusiness;
using OyunlarWebForms.BaModels;

namespace OyunlarWebForms.BaPages
{
    public partial class YilEkle : System.Web.UI.Page
    {
        private YilService yilService = new YilService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bKaydet_Click(object sender, EventArgs e)
        {
            YilModel model = new YilModel()
            {
                Degeri = tbDegeri.Text
            };

            Islem islem = yilService.Add(model);

            //if (islem == Islem.Basarili)
            //{
            //    Response.Redirect("Yillar.aspx");
            //}
            //else if (islem == Islem.BasarisizBosDeger)
            //{
            //    lBilgi.Text = "Boş değer girilemez!";
            //}
            //else if (islem == Islem.BasarisizKayitVar)
            //{
            //    lBilgi.Text = "Girdiğiniz değere sahip yıl kaydı bulunduğundan işlem gerçekleştirilemedi.";
            //}
            //else
            //{
            //    lBilgi.Text = "İşlem sırasında hata meydana geldi!";
            //}
            switch (islem)
            {
                case Islem.Basarili:
                    Response.Redirect("Yillar.aspx");
                    break;
                case Islem.BasarisizBosDeger:
                    lBilgi.Text = "Boş değer girilemez!";
                    break;
                case Islem.BasarisizKayitVar:
                    lBilgi.Text = "Girdiğiniz değere sahip yıl kaydı bulunduğundan işlem gerçekleştirilemedi.";
                    break;
                default:
                    lBilgi.Text = "İşlem sırasında hata meydana geldi!";
                    break;
            }
        }
    }
}