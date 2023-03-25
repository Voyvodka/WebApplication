using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using webapplication.core.Entity.Abstract;

namespace webapplication.core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(Expression<Func<T, bool>> filter);
    }
}
