﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp_TCMB_DovizKuru.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConsoleDbKurProjeEntities : DbContext
    {
        public ConsoleDbKurProjeEntities()
            : base("name=ConsoleDbKurProjeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<CurrencyValue> CurrencyValue { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
    }
}
