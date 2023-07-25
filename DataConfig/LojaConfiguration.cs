using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JucaSystem.DataConfig
{
    public class LojaConfiguration : IEntityTypeConfiguration<Loja>
    {
        public void Configure(EntityTypeBuilder<Loja> builder)
        {
            builder.ToTable("LOJA");

            builder.HasKey(l => l.LojaId);

            builder.Property(p => p.LojaId)
            .HasColumnName("CDLOJA")
            .IsRequired();

            builder.Property(p => p.DescricaoNome)
                .HasColumnName("DSNOME")
                .IsRequired();

            builder.Property(p => p.DescricaoEndereco)
            .HasColumnName("DSENDERECO")
            .IsRequired();

        }
    }
}
