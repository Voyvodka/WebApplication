using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity;
namespace webapplication.business.Abstracts
{
    public interface IAdminMenuHeaderService
    {
        public IDataResult<List<AdminMenuHeader>> GetAll(Expression<Func<AdminMenuHeader, bool>>? expression = null);
        public IDataResult<AdminMenuHeader> GetSingle(Expression<Func<AdminMenuHeader, bool>> expression);
        public IResult Add(AdminMenuHeader adminMenuHeader);
        public IResult Update(AdminMenuHeader adminMenuHeader);
        public IResult Delete(AdminMenuHeader adminMenuHeader);
    }
}