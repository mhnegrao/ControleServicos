using DomainLib.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleServico.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        string GetByName(string name);

        Task<List<Cliente>> GetWithName(string name);
    }
}