using ApiControleServico.Data;
using DomainLib.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleServico.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        public UserService(ApiControleServicoContext dbService) : base(dbService)
        {
        }

        public string InitialMessage()
        {
            return "Dados Api User";
        }

        public async Task AddDataTeste()
        {
            var item = new User
            {
                Ativo = true,
                DataAlteracao = DateTime.Now,
                DataInclusao = DateTime.Now,
                Email = "usuarioteste@email",
                Password = "teste",
                PasswordConfirm = "teste",
                IdTipo = 1,
                Username = "userteste"
            };

            await Add(item);
        }

        public async Task<List<User>> GetWithName(string name)
        {
            var result = await Task.FromResult(_context.Set<User>().Where(w => w.Username.Contains(name)));
            return result.ToList();
        }

        public bool ItemValido(User item)
        {
            bool result = true;
            if (!item.ModelIsValid())
            {
                return !result;
            }
            return result;
        }
    }
}