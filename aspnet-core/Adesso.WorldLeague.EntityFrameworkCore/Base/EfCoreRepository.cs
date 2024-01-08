using Adesso.WorldLeague.BaseEntities;
using Adesso.WorldLeague.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adesso.WorldLeague.Base
{
    public class EfCoreRepository<T> : IRepository<T> where T : Entity, new()
    {

        private readonly WorldLeagueDbContext _context;
        public EfCoreRepository(WorldLeagueDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await _context.Set<T>().SingleAsync(x => x.Id == id);
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> AsQueryable() 
        {
          return _context.Set<T>().AsQueryable();
        }

    }
}
