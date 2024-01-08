using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adesso.WorldLeague.Base
{
    public interface IRepository<T> where T : class
    {
        public Task InsertAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(Guid id);
        IQueryable<T> AsQueryable();
    }
}
