using ApiControleServico.Data;
using DomainLib.Entidades;

namespace ApiControleServico.Services
{
    public class OrdemServicoService : ServiceBase<OrdemServico>, IOrdemServicoService
    {
        public OrdemServicoService(ApiControleServicoContext dbService) : base(dbService)
        {
        }
    }
}