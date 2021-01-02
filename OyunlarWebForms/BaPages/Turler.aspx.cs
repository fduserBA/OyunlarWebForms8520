using OyunlarWebForms.BaBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class Turler : System.Web.UI.Page
    {
        private TurService turService = new TurService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // sayfa ilk yüklendiğinde
            {
                FillGrid();
            }
        }

        private void FillGrid()
        {
            gvTurler.DataSource = turService.GetList();
            gvTurler.DataBind();
            SetColumnVisibilities();
        }

        private void SetColumnVisibilities()
        {
            gvTurler.HeaderRow.Cells[1].Visible = false; // Id
            foreach (GridViewRow row in gvTurler.Rows)
            {
                row.Cells[1].Visible = false; // Id
            }
        }

        protected void gvTurler_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvTurler.SelectedRow.Cells[1].Text;
            Response.Redirect("TurDetayi.aspx?id=" + id);
        }

        protected void lbEkle_Click(object sender, EventArgs e)
        {
            Response.Redirect("TurEkle.aspx");
        }
    }
}