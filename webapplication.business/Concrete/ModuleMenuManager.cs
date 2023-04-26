using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Menu;
namespace webapplication.business.Concrete
{
    public class ModuleMenuManager : IModuleMenuService
    {
        private readonly IModuleMenuDal _moduleMenuDal;
        public ModuleMenuManager(IModuleMenuDal moduleMenuDal)
        {
            _moduleMenuDal = moduleMenuDal;
        }
        public IResult Add(ModuleMenu moduleMenu)
        {
            _moduleMenuDal.Add(moduleMenu);
            return new SuccessResult();
        }
        public IResult Delete(ModuleMenu moduleMenu)
        {
            _moduleMenuDal.Delete(moduleMenu);
            return new SuccessResult();
        }
        public IDataResult<List<ModuleMenu>> GetAll(Expression<Func<ModuleMenu, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<ModuleMenu>>(_moduleMenuDal.GetList());
            }
            return new SuccessDataResult<List<ModuleMenu>>(_moduleMenuDal.GetList(expression));
        }
        public IDataResult<ModuleMenu> GetSingle(Expression<Func<ModuleMenu, bool>> expression)
        {
            return new SuccessDataResult<ModuleMenu>(_moduleMenuDal.Get(expression));
        }
        public IResult Update(ModuleMenu moduleMenu)
        {
            _moduleMenuDal.Update(moduleMenu);
            return new SuccessResult();
        }
    }
}