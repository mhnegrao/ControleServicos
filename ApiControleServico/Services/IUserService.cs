using DomainLib.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleServico.Services
{
    public interface IUserService : IServiceBase<User>
    {
        string InitialMessage();

        Task AddDataTeste();

        Task<List<User>> GetWithName(string name);

        bool ItemValido(User item);
    }
}