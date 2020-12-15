using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServico.Data
{
    internal class DocumentoMap : IEntityTypeConfiguration<Documento>
    {
        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.ToTable("Documento");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdTipo)
                .HasColumnName("IdTipo")
                .IsRequired(true);
            builder.Property(x => x.IdCliente)
                .HasColumnName("IdCliente")
                .HasColumnType("int")
                .IsRequired(true);
            builder.Property(x => x.Numero)
                .HasColumnName("Numero")
                .HasColumnType("varchar(20)")
                .HasMaxLength(15);
        }
    }
}