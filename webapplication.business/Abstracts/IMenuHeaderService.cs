using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity;
namespace webapplication.business.Abstracts
{
    public interface IMenuHeaderService
    {
        public IDataResult<List<MenuHeader>> GetAll(Expression<Func<MenuHeader, bool>>? expression = null);
        public IDataResult<MenuHeader> GetSingle(Expression<Func<MenuHeader, bool>> expression);
        public IResult Add(MenuHeader menuHeader);
        public IResult Update(MenuHeader menuHeader);
        public IResult Delete(MenuHeader menuHeader);
    }
}