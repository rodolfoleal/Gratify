using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CrossSolar.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        protected GratifyDbContext _dbContext { get; set; }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<bool> InsertAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return (await _dbContext.SaveChangesAsync() >= 0);
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return (await _dbContext.SaveChangesAsync() >= 0);
        }
    }
}