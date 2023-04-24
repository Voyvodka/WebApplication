using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Menu;
namespace webapplication.business.Concrete
{
    public class MenuModuleManager : IMenuModuleService
    {
        private readonly IMenuModuleDal _menuModuleDal;
        public MenuModuleManager(IMenuModuleDal menuModuleDal)
        {
            _menuModuleDal = menuModuleDal;
        }
        public IResult Add(MenuModule menuModule)
        {
            _menuModuleDal.Add(menuModule);
            return new SuccessResult();
        }
        public IResult Delete(MenuModule menuModule)
        {
            _menuModuleDal.Delete(menuModule);
            return new SuccessResult();
        }
        public IDataResult<List<MenuModule>> GetAll(Expression<Func<MenuModule, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<MenuModule>>(_menuModuleDal.GetList());
            }
            return new SuccessDataResult<List<MenuModule>>(_menuModuleDal.GetList(expression));
        }
        public IDataResult<MenuModule> GetSingle(Expression<Func<MenuModule, bool>> expression)
        {
            return new SuccessDataResult<MenuModule>(_menuModuleDal.Get(expression));
        }
        public IResult Update(MenuModule menuModule)
        {
            _menuModuleDal.Update(menuModule);
            return new SuccessResult();
        }
    }
}