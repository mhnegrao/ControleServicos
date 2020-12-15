using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServico.Data
{
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired(true);
            builder.Property(x => x.Celular)
                .HasColumnType("varchar(15)")
                .HasMaxLength(20)
                .IsRequired(true);
            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired(true);
            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasColumnType("VARCHAR(12)")
                .IsRequired(true);
            builder.Property(x => x.Observacao);
        }
    }
}