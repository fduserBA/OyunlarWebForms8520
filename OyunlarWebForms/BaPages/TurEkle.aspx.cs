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
    public partial class TurEkle : System.Web.UI.Page
    {
        private TurService turService = new TurService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bKaydet_Click(object sender, EventArgs e)
        {
            TurModel model = new TurModel()
            {
                Adi = tbAdi.Text.Trim()
            };
            if (turService.Add(model) == 0)
            {
                Response.Redirect("Turler.aspx");
            }
            else
            {
                lBilgi.Text = "Veritabanında girmiş olduğunuz ada sahip kayıt bulunduğundan işlem gerçekleştirilemedi.";
            }
        }
    }
}