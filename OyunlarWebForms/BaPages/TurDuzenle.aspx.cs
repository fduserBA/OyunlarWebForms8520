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
    public partial class TurDuzenle : System.Web.UI.Page
    {
        private TurService turService = new TurService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["turid"] == null)
                {
                    Response.Redirect("Turler.aspx");
                }
                else
                {
                    string idSession = Session["turid"].ToString();
                    //lBilgi.Text = idSession;

                    var model = turService.GetById(Convert.ToInt32(idSession));
                    tbAdi.Text = model.Adi;
                }
            }
        }

        protected void bKaydet_Click(object sender, EventArgs e)
        {
            string idSession = Session["turid"].ToString();
            var model = new TurModel()
            {
                Id = Convert.ToInt32(idSession),
                Adi = tbAdi.Text.Trim()
            };
            if (turService.Update(model))
            {
                lBilgi.Text = "Tür başarıyla güncellendi.";
            }
            else
            {
                lBilgi.Text = "Veritabanında girdiğiniz ada sahip kayıt bulunduğundan işlem gerçekleştirilemedi.";
            }
        }

        protected void bDetay_Click(object sender, EventArgs e)
        {
            string idSession = Session["turid"].ToString();
            Response.Redirect("TurDetayi.aspx?id=" + idSession);
        }
    }
}