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
    public partial class YilDuzenle : System.Web.UI.Page
    {
        private YilService yilService = new YilService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(id))
                {
                    Response.Redirect("Yillar.aspx");
                }
                else
                {
                    YilModel model = yilService.GetById(Convert.ToInt32(id));
                    tbDegeri.Text = model.Degeri;
                }
            }
        }

        protected void bKaydet_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            YilModel model = new YilModel()
            {
                Id = Convert.ToInt32(id),
                Degeri = tbDegeri.Text
            };
            Islem islem = yilService.Update(model);
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

        protected void bDetay_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            Response.Redirect("YilDetayi.aspx?id=" + id);
        }
    }
}