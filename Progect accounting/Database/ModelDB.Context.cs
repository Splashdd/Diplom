﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Progect_accounting.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Project_accounting_DBEntities : DbContext
    {
        private static Project_accounting_DBEntities _context;

        public static Project_accounting_DBEntities GetContext()
        {
            if (_context == null)
                _context = new Project_accounting_DBEntities();
            return _context;
        }
        public Project_accounting_DBEntities()
            : base("name=Project_accounting_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Supervisors> Supervisors { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}