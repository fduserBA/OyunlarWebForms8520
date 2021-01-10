using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunlarWinForms._2_Business.Models
{
    public class OyunModel
    {
        public int Id { get; set; }

        public string Adi { get; set; }

        public double? Maliyeti { get; set; }

        public double? Kazanci { get; set; }

        public int YilId { get; set; } // 2021



        public string KarZarar { get; set; }



        //public List<string> TurAdlari { get; set; }
        //public List<int> TurIdleri { get; set; }
        public List<TurModel> Turler { get; set; }
    }
}
