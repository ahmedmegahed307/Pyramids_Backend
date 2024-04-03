using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Repositories;
using System.Linq.Expressions;
using Pyramids.Core.IServices;
using Pyramids.Shared.Entity;
using System.Transactions;
using Pyramids.Core.UnitOfWork;

namespace Pyramids.Data.Repositories
{
    public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var e = await _dbSet.AddAsync(entity);
            return e.Entity;
        }
        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var properties = typeof(TEntity).GetProperties();

            foreach (var entity in entities)
            {
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(DateTime))
                    {
                        DateTime originalDate = (DateTime)property.GetValue(entity);

                        if (originalDate.Kind == DateTimeKind.Local)
                        {
                            property.SetValue(entity, originalDate.ToUniversalTime());
                        }
                    }

                    if (property.PropertyType == typeof(DateTime?))
                    {
                        var nullableDate = (DateTime?)property.GetValue(entity);

                        if (nullableDate.HasValue && nullableDate.Value.Kind == DateTimeKind.Local)
                        {
                            property.SetValue(entity, nullableDate.Value.ToUniversalTime());
                        }
                    }
                }
            }

            await _dbSet.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool? isActive = null, int? companyId = null, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (isActive.HasValue && typeof(IActiveEntity).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(e => ((IActiveEntity)e).IsActive == isActive.Value);
            }

            // Add a condition to filter by companyId if it's provided
            if (companyId.HasValue && typeof(ICompanyEntity).IsAssignableFrom(typeof(TEntity)))
            {
                query = query.Where(e => ((ICompanyEntity)e).CompanyId == companyId.Value);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }




        public void Remove(TEntity entity)
        {
            var property = entity.GetType().GetProperty("IsDeleted");
            var property2 = entity.GetType().GetProperty("IsActive");
            if (property != null && property.PropertyType == typeof(bool))
            {
                property.SetValue(entity, true);
                property2.SetValue(entity, false);
            }
        }

        public void Restore(TEntity entity)
        {
            var property = entity.GetType().GetProperty("IsDeleted");
            var property2 = entity.GetType().GetProperty("IsActive");
            if (property != null && property.PropertyType == typeof(bool))
            {
                property.SetValue(entity, false);
                property2.SetValue(entity, true);
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
            => _dbSet.RemoveRange(entities);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.SingleOrDefaultAsync(predicate);

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate , string? includeProperties = null)
        //=> await _dbSet.Where(predicate).ToListAsync();
        {
            IQueryable<TEntity> query = _dbSet;

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return  query.Where(predicate);
        }
        public async Task<IEnumerable<TEntity>> WhereIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate)
        {
            using (TransactionScope TransactionScope = new TransactionScope(TransactionScopeOption.Required,
            new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadUncommitted
            }))
            {

                return _dbSet.Where(predicate);
            }
        }
        public  void RemoveWhere(Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> values = FindWhere(predicate).ToList();
            if (values != null)
            {
                foreach (TEntity value in values)
                {
                    Remove(value);
                }
            }
        }
    }
}
