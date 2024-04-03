using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.IServices
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id, string? includeProperties = null);
        Task<IEnumerable<TEntity>> GetAllAsync(bool? isActive = null, int? CompanyId=null, string? includeProperties = null);
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> WhereIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void Restore(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity> Update(int id, TEntity entity);
    }
}
