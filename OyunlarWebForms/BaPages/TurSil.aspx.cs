using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OyunlarWebForms.BaBusiness;

namespace OyunlarWebForms.BaPages
{
    public partial class TurSil : System.Web.UI.Page
    {
        private TurService turService = new TurService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string idQueryString = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(idQueryString))
                {
                    Response.Redirect("Turler.aspx");
                }
                else
                {
                    var model = turService.GetById(Convert.ToInt32(idQueryString));
                    lAdi.Text = model.Adi;
                }
            }
        }

        protected void bEvet_Click(object sender, EventArgs e)
        {
            string idQueryString = Request.QueryString["id"];
            turService.Delete(Convert.ToInt32(idQueryString));
            Response.Redirect("Turler.aspx");
        }

        protected void bHayir_Click(object sender, EventArgs e)
        {
            string idQueryString = Request.QueryString["id"];
            Response.Redirect("TurDetayi.aspx?id=" + idQueryString);
        }
    }
}