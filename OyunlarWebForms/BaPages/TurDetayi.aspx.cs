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
    public partial class TurDetayi : System.Web.UI.Page
    {
        private TurService turService = new TurService();

        private string idQueryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // istek: Request
            // yanıt: Reponse
            // QueryString örnek:
            //string firma = Request.QueryString["firma"]; // http://domain.com/TurDetayi.aspx?firma=BilgeAdam
            //string sehir = Request.QueryString["sehir"]; // http://domain.com/TurDetayi.aspx?firma=BilgeAdam&sehir=Ankara
            // https://www.google.com/search?q=Türkiye
            //lBilgi.Text = "Firma: " + firma + ", Şehir: " + sehir;
            idQueryString = Request.QueryString["id"]; // http://domain.com/TurDetayi.aspx?id=5

            if (!Page.IsPostBack) // sayfa ilk yüklenirken
            {
                if (string.IsNullOrWhiteSpace(idQueryString))
                {
                    Response.Redirect("Turler.aspx"); // sayfaya yönlendirme
                }
                else
                {
                    int id = Convert.ToInt32(idQueryString);
                    TurModel model = turService.GetById(id);
                    lAdi.Text = model.Adi;
                    lBilgi.Text = "Tür detayı başarıyla getirildi.";
                }
            }
        }

        protected void ibDuzenle_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("TurDuzenle.aspx?id=" + idQueryString);
            Session["turid"] = idQueryString;
            Response.Redirect("TurDuzenle.aspx");
        }

        protected void ibSil_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("TurSil.aspx?id=" + idQueryString);
        }
    }
}