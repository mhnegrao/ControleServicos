using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServico.Data
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .UseIdentityColumn(1);
            builder.Property(x => x.IdTipo)
                .HasColumnName("IdTipo")
                .IsRequired(true);
            builder.Property(x => x.Username)
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .IsRequired(true);
            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired(true);
            builder.Property(x => x.Password)
                .HasColumnType("varchar(15)")
                .IsRequired(true)
                .HasMaxLength(10);
        }
    }
}