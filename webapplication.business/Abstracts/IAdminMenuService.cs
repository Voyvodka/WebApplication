using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity;
namespace webapplication.business.Abstracts
{
    public interface IAdminMenuService
    {
        public IDataResult<List<AdminMenu>> GetAll(Expression<Func<AdminMenu, bool>>? expression = null);
        public IDataResult<AdminMenu> GetSingle(Expression<Func<AdminMenu, bool>> expression);
        public IResult Add(AdminMenu adminMenu);
        public IResult Update(AdminMenu adminMenu);
        public IResult Delete(AdminMenu adminMenu);
    }
}