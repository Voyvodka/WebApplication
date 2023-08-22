using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.DataAccess;
using webapplication.core.Entity.Abstract;
namespace webapplication.business.Concrete
{
    public class BaseCrudManager<TEntity> : IBaseCrudService<TEntity> where TEntity : IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _entityDal;
        public BaseCrudManager(IEntityRepository<TEntity> entityDal)
        {
            _entityDal = entityDal;
        }
        public void Add(TEntity entity)
        {
            _entityDal.Add(entity);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _entityDal.AddAsync(entity);
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return await _entityDal.AnyAsync(filter);
        }
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            return await _entityDal.CountAsync(filter);
        }
        public void Delete(TEntity entity)
        {
            _entityDal.Delete(entity);
        }
        public async Task DeleteAsync(TEntity entity)
        {
            await _entityDal.DeleteAsync(entity);
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _entityDal.Get(filter, checkPassive, includeProperties);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _entityDal.GetAsync(filter, checkPassive, includeProperties);
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _entityDal.GetList(filter, checkPassive, includeProperties);
        }
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await _entityDal.GetListAsync(filter, checkPassive, includeProperties);
        }
        public IQueryable<TEntity> GetQueryableList(Expression<Func<TEntity, bool>>? filter = null, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return _entityDal.GetQueryableList(filter, checkPassive, includeProperties);
        }
        public void Update(TEntity entity)
        {
            _entityDal.Update(entity);
        }
        public async Task UpdateAsync(TEntity entity)
        {
            await _entityDal.UpdateAsync(entity);
        }
    }
}