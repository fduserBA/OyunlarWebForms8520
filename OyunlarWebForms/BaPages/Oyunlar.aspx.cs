using OyunlarWebForms.BaEntities;
using OyunlarWebForms.BaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OyunlarWebForms.BaPages
{
    public partial class Oyunlar : System.Web.UI.Page
    {
        private OyunlarContext db = new OyunlarContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {
            List<Oyun> oyunlarEntity = db.Oyun.ToList();
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
                YilDegeri = oyunEntity.Yil.Degeri
            }).ToList();

            gvOyunlar.DataSource = oyunlarModel;
            gvOyunlar.DataBind();
        }
    }
}