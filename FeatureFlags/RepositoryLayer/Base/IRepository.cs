using System.Linq.Expressions;
using FeatureFlags.DataLayer.Entities.Base;

namespace FeatureFlags.RepositoryLayer.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> SaveChangesAsync();

        Task<T?> FindByConditionAsync(Expression<Func<T, bool>> predicate);

        Task<bool> RemoveAsync(Guid id);
    }
}
