using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using webapplication.core.Entity.Abstract;
namespace webapplication.core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : IEntity
         where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }
        public async Task AddAsync(TEntity entity)
        {
            using var context = new TContext();
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.AnyAsync();
        }
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.CountAsync();
        }
        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>().Where(filter);
            if (checkPassive)
            {
                query = query.Where(e => !e.IsPassive);
            }
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            return query.SingleOrDefault();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>().OrderByDescending(c => c.CreatedDate);
            if (checkPassive)
            {
                Expression<Func<TEntity, bool>> passiveExpression = c => !c.IsPassive;
                query = query.Where(passiveExpression);
            }
            query = query.Where(filter);
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.FirstOrDefaultAsync();
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>().OrderByDescending(c => c.CreatedDate);
            if (checkPassive)
            {
                Expression<Func<TEntity, bool>> passiveExpression = c => c.IsPassive == false;
                query = query.Where(passiveExpression);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            return query.ToList();
        }
        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (checkPassive)
            {
                query = query.Where(e => !e.IsPassive);
            }
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.ToListAsync();
        }
        public IQueryable<TEntity> GetQueryableList(Expression<Func<TEntity, bool>>? filter = null, bool checkPassive = true, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            using var context = new TContext();
            IQueryable<TEntity> query = context.Set<TEntity>().OrderByDescending(c => c.CreatedDate);
            if (checkPassive)
            {
                Expression<Func<TEntity, bool>> passiveExpression = c => c.IsPassive == false;
                query = query.Where(passiveExpression);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }
            return query.ToList().AsQueryable();
        }
        public void Update(TEntity entity)
        {
            using var context = new TContext();
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new TContext();
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
