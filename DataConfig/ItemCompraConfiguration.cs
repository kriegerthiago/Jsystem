using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JucaSystem.DataConfig
{
    public class ItemCompraConfiguration : IEntityTypeConfiguration<ItemCompra>
    {
        public void Configure(EntityTypeBuilder<ItemCompra> builder)
        {
            builder.HasKey(p => p.ItemCompraId);

            builder.Property(p => p.ItemCompraId)
            .HasColumnName("CDITEMCOMPRA")
            .IsRequired();

            builder.Property(p => p.CompraId)
            .HasColumnName("CDCOMPRA")
            .IsRequired();
            builder.Property(p => p.ProdutoId)
            .HasColumnName("CDPRODUTO")
            .IsRequired();

            builder.Property(p => p.QuantidadeComprada)
            .HasColumnName("QTDEITEM")
            .IsRequired();
            builder.Property(p => p.ValorItem)
            .HasColumnName("VLTOTAL")
            .IsRequired();

            builder.Property(p => p.SequenciaItemCompra)
            .HasColumnName("SQITEMCOMPRA")
            .IsRequired();

            builder.HasOne(p => p.Compra)
            .WithMany(p => p.ItensCompra)
            .HasForeignKey(p => p.CompraId);

            builder.HasOne(p => p.Produto)
            .WithOne(p => p.ItemCompra)
            .HasForeignKey<ItemCompra>(p => p.ProdutoId);


        }
    }
}

