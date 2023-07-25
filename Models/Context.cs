using JucaSystem.DataConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JucaSystem.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<ItemCompra> ItensCompras { get; set; }
        public DbSet<Loja> Lojas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-DHN9EUA5;Database=jucadb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PessoaConfig(modelBuilder);
            ProdutoConfig(modelBuilder);
            ItemCompraConfig(modelBuilder);
            LojaConfiguration(modelBuilder);
            CompraConfig(modelBuilder);
            base.OnModelCreating(modelBuilder);

        }

        #region ConfigBuilder
        private void PessoaConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());

        }

        private void ProdutoConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }

        private void ItemCompraConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemCompraConfiguration());
        }

        private void LojaConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LojaConfiguration());
        }

        private void CompraConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompraConfiguration());
        }

        #endregion
    }
}

