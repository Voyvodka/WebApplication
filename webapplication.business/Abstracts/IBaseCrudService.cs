using System.Linq.Expressions;
using webapplication.core.Entity.Abstract;
namespace webapplication.business.Abstracts
{
    public interface IBaseCrudService<T> where T : IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter, bool checkPassive = true, params Expression<Func<T, object>>[] includeProperties);
        List<T> GetList(Expression<Func<T, bool>>? filter = null, bool checkPassive = true, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetQueryableList(Expression<Func<T, bool>>? filter = null, bool checkPassive = true, params Expression<Func<T, object>>[] includeProperties);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //Async
        Task<T> GetAsync(Expression<Func<T, bool>> filter, bool checkPassive = true, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>>? filter = null, bool checkPassive = true, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
        Task<bool> AnyAsync(Expression<Func<T, bool>>? filter = null);
    }
}