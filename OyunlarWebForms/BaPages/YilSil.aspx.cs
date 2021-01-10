using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OyunlarWebForms.BaBusiness;

namespace OyunlarWebForms.BaPages
{
    public partial class YilSil : System.Web.UI.Page
    {
        private YilService yilService = new YilService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idQueryString = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(idQueryString))
                {
                    Response.Redirect("Yillar.aspx");
                }
                else
                {
                    var model = yilService.GetById(Convert.ToInt32(idQueryString));
                    lDegeri.Text = model.Degeri;
                }
            }
        }

        protected void bEvet_Click(object sender, EventArgs e)
        {
            string idQueryString = Request.QueryString["id"];
            Islem islem = yilService.Delete(Convert.ToInt32(idQueryString));
            if (islem == Islem.Basarili)
            {
                Response.Redirect("Yillar.aspx");
            }
            else if (islem == Islem.BasarisizIliskiliKayitVar)
            {
                lBilgi.Text = "Silmek istediğiniz yıl kaydı ile ilişkili oyun kaydı bulunduğundan işlem gerçekleştirilemedi.";
            }
            else
            {
                lBilgi.Text = "İşlem sırasında hata meydana geldi!";
            }
        }

        protected void bHayir_Click(object sender, EventArgs e)
        {
            string idQueryString = Request.QueryString["id"];
            Response.Redirect("YilDetayi.aspx?id=" + idQueryString);
        }
    }
}