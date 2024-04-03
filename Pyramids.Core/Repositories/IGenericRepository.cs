using System.Linq.Expressions;

namespace Pyramids.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id ,string? includeProperties = null);
        Task<IEnumerable<TEntity>> GetAllAsync(bool? isActive = null, int? companyId = null, string? includeProperties = null);
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate, string? includeProperties = null);
        Task<IEnumerable<TEntity>> WhereIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void Restore(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate);

        void RemoveWhere(Expression<Func<TEntity, bool>> predicate);

    }
}
