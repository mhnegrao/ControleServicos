using DomainLib.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleServico.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        public ClienteService(Data.ApiControleServicoContext dbService) : base(dbService)
        {
        }

        public string GetByName(string name)
        {
            return "<h2>Texto retornado da API cliente</h2>";
        }

        public async Task<List<Cliente>> GetWithName(string name)
        {
            var result = await Task.FromResult(_context.Set<Cliente>().Where(w => w.Nome.Contains(name)));
            return result.ToList();
        }
    }
}