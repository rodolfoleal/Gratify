using CrossSolar.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace Gratify.Business
{
    public abstract class GenericBusiness<T> : IGenericBusiness<T>
   where T : class, new()
    {
        protected IGenericRepository<T> _repository { get; set; }

        public GenericBusiness(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public IQueryable<T> Query()
        {
            return _repository.Query().AsQueryable();
        }

        public async Task<bool> InsertAsync(T entity)
        {
           return await _repository.InsertAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
           return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            return await _repository.RemoveAsync(entity);
        }
    }
}