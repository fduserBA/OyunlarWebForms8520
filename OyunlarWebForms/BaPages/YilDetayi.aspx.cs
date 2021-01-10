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
    public partial class YilDetayi : System.Web.UI.Page
    {
        private YilService yilService = new YilService();

        private string idQueryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            idQueryString = Request.QueryString["id"]; 

            if (!Page.IsPostBack) // sayfa ilk yüklenirken
            {
                if (string.IsNullOrWhiteSpace(idQueryString))
                {
                    Response.Redirect("Yillar.aspx"); // sayfaya yönlendirme
                }
                else
                {
                    int id = Convert.ToInt32(idQueryString);
                    YilModel model = yilService.GetById(id);
                    lDegeri.Text = model.Degeri;
                    lBilgi.Text = "Yıl detayı başarıyla getirildi.";
                }
            }
        }

        protected void ibDuzenle_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("YilDuzenle.aspx?id=" + idQueryString);
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("YilSil.aspx?id=" + idQueryString);
        }
    }
}