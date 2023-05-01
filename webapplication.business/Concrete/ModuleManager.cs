using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Menu;
namespace webapplication.business.Concrete
{
    public class ModuleManager : IModuleService
    {
        private readonly IModuleDal _moduleDal;
        public ModuleManager(IModuleDal moduleDal)
        {
            _moduleDal = moduleDal;
        }
        public IResult Add(Module module)
        {
            _moduleDal.Add(module);
            return new SuccessResult();
        }
        public IResult Delete(Module module)
        {
            _moduleDal.Delete(module);
            return new SuccessResult();
        }
        public IDataResult<List<Module>> GetAll(Expression<Func<Module, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Module>>(_moduleDal.GetList());
            }
            return new SuccessDataResult<List<Module>>(_moduleDal.GetList(expression));
        }
        public IDataResult<Module> GetSingle(Expression<Func<Module, bool>> expression)
        {
            return new SuccessDataResult<Module>(_moduleDal.Get(expression));
        }
        public IResult Update(Module module)
        {
            _moduleDal.Update(module);
            return new SuccessResult();
        }
    }
}