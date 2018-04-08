using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SalesDataImporter.Models;

namespace SalesDataImporter.DAL
{
    public class SalesDataImporterContext : DbContext
    {
        public SalesDataImporterContext() : base("SalesDataImporterContext")
        {
            Database.CreateIfNotExists();
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<DadosVenda> DadosVendas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}