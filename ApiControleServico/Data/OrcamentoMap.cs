using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServico.Data
{
    internal class OrcamentoMap : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("Orcamento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeContato)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired(true);
            builder.Property(x => x.FoneContato)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired(true);
            builder.Property(x => x.EmailContato)
                .HasColumnType("varchar(50)")
                .HasMaxLength(30)
                .IsRequired(true);
            builder.Property(x => x.DataValidade)
                .HasColumnType("DATETIME")
                .IsRequired(true);
            builder.Property(x => x.ValorSugerido)
                .HasColumnType("DECIMAL(10,2)")
                .IsRequired(true);
            builder.Property(x => x.AprovadoPor)
                .IsRequired(false)
                .HasColumnType("VARCHAR(30)");
            builder.Property(x => x.IdOperador)
                .HasColumnType("int")
                .IsRequired(true);

            builder.Property(x => x.Observacao).IsRequired(false);
        }
    }
}