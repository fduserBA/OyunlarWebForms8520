using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace OyunlarWinForms._1_Entities
{
    public partial class OyunlarDB : DbContext
    {
        public OyunlarDB()
            : base("name=OyunlarContext")
        {
        }

        public virtual DbSet<Oyun> Oyun { get; set; }
        public virtual DbSet<OyunTur> OyunTur { get; set; }
        public virtual DbSet<Tur> Tur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oyun>()
                .HasMany(e => e.OyunTur)
                .WithRequired(e => e.Oyun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tur>()
                .HasMany(e => e.OyunTur)
                .WithRequired(e => e.Tur)
                .WillCascadeOnDelete(false);
        }
    }
}
