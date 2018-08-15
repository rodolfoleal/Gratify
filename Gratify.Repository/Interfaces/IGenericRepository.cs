using System.Linq;
using System.Threading.Tasks;

namespace CrossSolar.Repository
{
    public interface IGenericRepository<T>
    {
        Task<T> GetAsync(int id);

        IQueryable<T> Query();

        Task<bool> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> RemoveAsync(T entity);
    }
}