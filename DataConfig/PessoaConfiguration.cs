using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JucaSystem.DataConfig
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PESSOA");

            builder.HasKey(l => l.PessoaId);

            builder.Property(p => p.PessoaId)
            .HasColumnName("CDPESSOA")
            .IsRequired();

            builder.Property(p => p.DescricaoNome)
                .HasColumnName("DSNOME")
                .IsRequired();

            builder.Property(p => p.NumeroTelefone)
            .HasColumnName("NRTELEFONE")
            .IsRequired();

            builder.Property(p => p.NumeroDDD)
            .HasColumnName("NRDDD")
            .IsRequired();

            builder.Property(p => p.DescricaoObservacaoReferencia)
            .HasColumnName("DSOBSERVACAOREFERENCIA");
        }
    }
}
