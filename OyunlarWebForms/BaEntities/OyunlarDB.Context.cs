﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OyunlarWebForms.BaEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OyunlarContext : DbContext
    {
        public OyunlarContext()
            : base("name=OyunlarContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Oyun> Oyun { get; set; }
        public virtual DbSet<OyunTur> OyunTur { get; set; }
        public virtual DbSet<Tur> Tur { get; set; }
        public virtual DbSet<Yil> Yil { get; set; }
    }
}