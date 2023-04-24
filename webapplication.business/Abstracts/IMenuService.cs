using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity.Menu;
namespace webapplication.business.Abstracts
{
    public interface IMenuService
    {
        public IDataResult<List<Menu>> GetAll(Expression<Func<Menu, bool>>? expression = null);
        public IDataResult<Menu> GetSingle(Expression<Func<Menu, bool>> expression);
        public IResult Add(Menu menu);
        public IResult Update(Menu menu);
        public IResult Delete(Menu menu);
    }
}