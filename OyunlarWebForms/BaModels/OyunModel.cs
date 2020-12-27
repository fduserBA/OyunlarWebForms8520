﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OyunlarWebForms.BaModels
{
    /// <summary>
    /// Sayfalarda kullanılmak üzere hem entity'den gelen hem de kendi ihtiyacımız olan özellikleri içeren sınıf
    /// </summary>
    public class OyunModel
    {
        #region Entity'de bulunan ve veritabanı sütunlarına karşılık gelen özellikler
        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        public string Adi { get; set; }

        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        //public Nullable<double> Maliyeti { get; set; }
        public double? Maliyeti { get; set; }

        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        //public Nullable<double> Kazanci { get; set; }
        public double? Kazanci { get; set; }

        /// <summary>
        /// Entity'den gelen tablo ile ilgili özellik
        /// </summary>
        public int YilId { get; set; }
        #endregion

        #region Kendi ihtiyacımız için eklediğimiz özellikler
        /// <summary>
        /// Sayfalarda kullanılmak üzere kendi ihtiyacım olan özellik
        /// </summary>
        public string YilDegeri { get; set; }

        /// <summary>
        /// Sayfalarda kullanılmak üzere kendi ihtiyacım olan özellik
        /// </summary>
        public string KarZarar { get; set; }
        #endregion
    }
}