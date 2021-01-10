namespace OyunlarWinForms._1_Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oyun")]
    public partial class Oyun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oyun()
        {
            OyunTur = new HashSet<OyunTur>();
        }

        public int Id { get; set; }

        public string Adi { get; set; }

        public double? Maliyeti { get; set; }

        public double? Kazanci { get; set; }

        public int YilId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OyunTur> OyunTur { get; set; }
    }
}
