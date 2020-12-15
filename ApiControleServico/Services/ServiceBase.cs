using ApiControleServico.Data;
using DomainLib.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiControleServico.Services
{
    //usando a abordagem de disposing para executar os serviços
    public class ServiceBase<T> : BaseEntity, IServiceBase<T> where T : class
    {
        protected readonly ApiControleServicoContext _context;

        public ServiceBase(ApiControleServicoContext dbService)
        {
            _context = dbService;
        }

        public async Task Add(T item)
        {
            // using (var ctx = _context)
            {
                await _context.Set<T>().AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<T>> GetAll()
        {
            var result = await _context.Set<T>().AsNoTracking().ToListAsync();
            return result.ToList();
        }

        public async Task<T> GetById(int id)
        {
            var result = await _context.Set<T>().FindAsync(id);
            return result;
        }

        public Task Remove(int id)
        {
            var item = _context.Set<T>().FindAsync(id).Result;

            if (item != null)
            {
                _context.Set<T>().Remove(item);
                return _context.SaveChangesAsync();
            }
            return null;
        }

        public Task Remove(T item)
        {
            if (item != null)
            {
                _context.Set<T>().Remove(item);
                return _context.SaveChangesAsync();
            }
            return null;
        }

        public Task Update(int id)
        {
            var item = _context.Set<T>().FindAsync(id);

            _context.Entry(item).State = EntityState.Modified;

            return _context.SaveChangesAsync();
        }

        public Task Update(T item)
        {
            try
            {
                if (item != null)
                {
                    _context.Entry(item).State = EntityState.Detached;
                    _context.Update(item);
                    return _context.SaveChangesAsync();
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}