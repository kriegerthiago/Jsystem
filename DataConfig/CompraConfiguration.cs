using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JucaSystem.DataConfig
{
    public class CompraConfiguration : IEntityTypeConfiguration<Compra>
    {
        public void Configure(EntityTypeBuilder<Compra> builder)
        {

            builder.ToTable("COMPRA");

            builder.HasKey(l => l.CompraId);

            builder.Property(p => p.CompraId)
            .HasColumnName("CDCOMPRA")
            .IsRequired();

            builder.Property(p => p.PessoaId)
                .HasColumnName("CDPESSOA")
                .IsRequired();

            builder.Property(p => p.LojaId)
            .HasColumnName("CDLOJA")
            .IsRequired();

            builder.Property(p => p.QuantidadeProduto)
            .HasColumnName("QTDEPRODUTO")
            .IsRequired();

            builder.Property(p => p.DataCompra)
            .HasColumnName("DTCOMPRA")
            .IsRequired();

            builder.Property(p => p.DescricaoObservacao)
            .HasColumnName("DSOBSERVACAO")
            .IsRequired();

            builder.Property(p => p.FoiPago)
            .HasColumnName("IDPAGO")
            .IsRequired();

            builder.HasOne(p => p.Pessoa)
            .WithOne(p => p.Compras)
            .HasForeignKey<Compra>(p => p.PessoaId);

            builder.HasOne(p => p.Loja)
            .WithOne(p => p.Compras)
            .HasForeignKey<Compra>(p => p.LojaId);

            builder.HasMany(p => p.ItensCompra)
                .WithOne(p => p.Compra)
                .HasForeignKey(p => p.CompraId);

        }
    }
}
