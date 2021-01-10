using OyunlarWinForms._2_Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlarWinForms._2_Business.Services
{
    public class YilService
    {
        public List<YilModel> GetList()
        {
            List<YilModel> yillar = new List<YilModel>();
            for (int i = DateTime.Now.Year + 1; i >= 1980; i--)
            {
                yillar.Add(new YilModel()
                {
                    Id = i,
                    Degeri = i.ToString()
                });
            }
            return yillar;
        }
    }
}
