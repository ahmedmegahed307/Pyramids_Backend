using Pyramids.Core.Repositories;
using Pyramids.Core.IServices;
using Pyramids.Core.UnitOfWork;
using System.Linq.Expressions;

namespace Pyramids.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<TEntity> _repository;
        public Service(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;

        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var properties = typeof(TEntity).GetProperties();

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
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
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

            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool? isActive = null, int? companyId = null, string? includeProperties = null)
            => await _repository.GetAllAsync(isActive,companyId, includeProperties);
        public async Task<TEntity> GetByIdAsync(int id, string? includeProperties = null)
            => await _repository.GetByIdAsync(id, includeProperties);
        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }
        public void Restore(TEntity entity)
        {
            _repository.Restore(entity);
            _unitOfWork.Commit();
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();
        }
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
            => await _repository.SingleOrDefaultAsync(predicate);
        public async Task<TEntity> Update(int id, TEntity entity)
        {
            TEntity updateEntity = _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return updateEntity;
        }
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
            => await _repository.Where(predicate);

        public async Task<IEnumerable<TEntity>> WhereIncluding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _repository.WhereIncluding(predicate, includeProperties);
        }
    }
}
