using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity;
namespace webapplication.business.Abstracts
{
    public interface IModuleMenuService
    {
        public IDataResult<List<ModuleMenu>> GetAll(Expression<Func<ModuleMenu, bool>>? expression = null);
        public IDataResult<ModuleMenu> GetSingle(Expression<Func<ModuleMenu, bool>> expression);
        public IResult Add(ModuleMenu moduleMenu);
        public IResult Update(ModuleMenu moduleMenu);
        public IResult Delete(ModuleMenu moduleMenu);
    }
}