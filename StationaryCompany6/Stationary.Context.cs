﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StationaryCompany6
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StationeryCompanyEntities : DbContext
    {
        public StationeryCompanyEntities()
            : base("name=StationeryCompanyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Managers> Managers { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
    }
}
