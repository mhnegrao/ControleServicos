using ApiControleServico.Data;
using DomainLib.Entidades;

namespace ApiControleServico.Services
{
    public class OrcamentoService : ServiceBase<Orcamento>, IOrcamentoService
    {
        public OrcamentoService(ApiControleServicoContext dbService) : base(dbService)
        {
        }
    }
}