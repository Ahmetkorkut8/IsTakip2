﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsTakip.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBIstakipEntities : DbContext
    {
        public DBIstakipEntities()
            : base("name=DBIstakipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BIRIMLER> BIRIMLER { get; set; }
        public virtual DbSet<DURUMLAR> DURUMLAR { get; set; }
        public virtual DbSet<ISLER> ISLER { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<T_PERSONEL> T_PERSONEL { get; set; }
        public virtual DbSet<YETKI_TURLERI> YETKI_TURLERI { get; set; }
    }
}
