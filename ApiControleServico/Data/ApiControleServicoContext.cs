using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiControleServico.Data
{
    public class ApiControleServicoContext : DbContext
    {
        public ApiControleServicoContext(DbContextOptions<ApiControleServicoContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Documento> Documento { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Orcamento> Orcamento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<OrdemServico> Servico { get; set; }
        public DbSet<OrdemServicoItem> ServicoItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new OrcamentoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoItemMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoItemMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}