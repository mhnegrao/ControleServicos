using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControleServico.Data
{
    internal class OrdemServicoItemMap : IEntityTypeConfiguration<OrdemServicoItem>
    {
        public void Configure(EntityTypeBuilder<OrdemServicoItem> builder)
        {
            builder.ToTable("OrdemServicoItem");
            builder.HasKey(x => x.Id);
        }
    }
}