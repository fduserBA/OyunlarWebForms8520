using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OyunlarWebForms.BaModels
{
    public class OyunModel
    {
        #region Entity'de bulunan ve veritabanı sütunlarına karşılık gelen özellikler
        public int Id { get; set; }
        public string Adi { get; set; }
        public Nullable<double> Maliyeti { get; set; }
        public Nullable<double> Kazanci { get; set; }
        public int YilId { get; set; }
        #endregion

        #region Kendi ihtiyacımız için eklediğimiz özellikler
        public string YilDegeri { get; set; }
        #endregion
    }
}