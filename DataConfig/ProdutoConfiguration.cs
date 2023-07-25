using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JucaSystem.DataConfig
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.HasKey(l => l.ProdutoId);

            builder.Property(p => p.ProdutoId)
            .HasColumnName("CDPRODUTO")
            .IsRequired();

            builder.Property(p => p.DescricaoProduto)
                .HasColumnName("DSPRODUTO")
                .IsRequired();

            builder.Property(p => p.ValorProduto)
            .HasColumnName("VLPRODUTO")
            .IsRequired();

            builder.Property(p => p.QuantidadeMultiploProduto)
            .HasColumnName("QTDEMULTIPLOPRODUTO");



            builder.Property(p => p.DescricaoObservacao)
            .HasColumnName("DSOBSERVACAO");
        }
    }
}
