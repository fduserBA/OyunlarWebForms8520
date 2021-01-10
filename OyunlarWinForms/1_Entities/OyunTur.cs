namespace OyunlarWinForms._1_Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OyunTur")]
    public partial class OyunTur
    {
        public int Id { get; set; }

        public int OyunId { get; set; }

        public int TurId { get; set; }

        public virtual Oyun Oyun { get; set; }

        public virtual Tur Tur { get; set; }
    }
}
