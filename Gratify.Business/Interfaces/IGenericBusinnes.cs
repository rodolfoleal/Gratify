using System.Linq;
using System.Threading.Tasks;

namespace Gratify.Business
{
    public interface IGenericBusiness<T> where T : class, new()
    {
        Task<T> GetAsync(int id);

        IQueryable<T> Query();

        Task<bool> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> RemoveAsync(T entity);
    }
}