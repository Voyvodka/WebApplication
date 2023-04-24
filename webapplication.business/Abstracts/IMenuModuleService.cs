using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity.Menu;
namespace webapplication.business.Abstracts
{
    public interface IMenuModuleService
    {
        public IDataResult<List<MenuModule>> GetAll(Expression<Func<MenuModule, bool>>? expression = null);
        public IDataResult<MenuModule> GetSingle(Expression<Func<MenuModule, bool>> expression);
        public IResult Add(MenuModule menuModule);
        public IResult Update(MenuModule menuModule);
        public IResult Delete(MenuModule menuModule);
    }
}