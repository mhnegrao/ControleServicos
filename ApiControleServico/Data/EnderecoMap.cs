using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServico.Data
{
    internal class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Logradouro)
                .IsRequired(true)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
            builder.Property(x => x.Municipio)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired(true);
            builder.Property(x => x.Uf)
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired(true);
            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired(true);
            builder.Property(x => x.Cep)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8)
                .IsRequired(true);
        }
    }
}