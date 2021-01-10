using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OyunlarWinForms._1_Entities;
using OyunlarWinForms._2_Business.Models;

namespace OyunlarWinForms._2_Business.Services
{
    public class OyunService
    {
        private OyunlarDB db = new OyunlarDB();

        public List<OyunModel> GetList()
        {
            try
            {
                return db.Oyun.OrderBy(o => o.Adi).Select(o => new OyunModel()
                {
                    Adi = o.Adi,
                    Id = o.Id,
                    Kazanci = o.Kazanci,
                    Maliyeti = o.Maliyeti,
                    YilId = o.YilId,
                    Turler = o.OyunTur.Select(ot => new TurModel()
                    {
                        Id = ot.Tur.Id, // ot.TurId
                        Adi = ot.Tur.Adi
                    }).ToList(),
                    KarZarar = (o.Kazanci ?? 0 - o.Maliyeti ?? 0).ToString(new CultureInfo("tr")) + " TL"
                }).ToList();
            }
            catch (Exception e)
            {
                //throw e;
                return null;
            }
        }
    }
}
