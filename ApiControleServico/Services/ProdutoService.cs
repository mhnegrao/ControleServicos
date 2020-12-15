using ApiControleServico.Data;
using DomainLib.Entidades;

namespace ApiControleServico.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        public ProdutoService(ApiControleServicoContext dbService) : base(dbService)
        {
        }
    }
}