using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiControleServico.Services
{
    public interface IServiceBase<T> : IDisposable where T : class
    {
        Task Add(T item);

        Task<T> GetById(int id);

        Task<List<T>> GetAll();

        Task Update(int id);

        Task Update(T item);

        Task Remove(int id);
    }
}