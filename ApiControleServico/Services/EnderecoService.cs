using ApiControleServico.Data;
using DomainLib.Entidades;

namespace ApiControleServico.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        public EnderecoService(ApiControleServicoContext dbService) : base(dbService)
        {
        }
    }
}