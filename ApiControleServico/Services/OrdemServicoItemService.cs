using ApiControleServico.Data;
using DomainLib.Entidades;

namespace ApiControleServico.Services
{
    public class OrdemServicoItemService : ServiceBase<OrdemServicoItem>, IOrdemServicoItemService
    {
        public OrdemServicoItemService(ApiControleServicoContext dbService) : base(dbService)
        {
        }
    }
}