using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity.Menu;
namespace webapplication.business.Abstracts
{
    public interface IModuleService
    {
        public IDataResult<List<Module>> GetAll(Expression<Func<Module, bool>>? expression = null);
        public IDataResult<Module> GetSingle(Expression<Func<Module, bool>> expression);
        public IResult Add(Module module);
        public IResult Update(Module module);
        public IResult Delete(Module module);
    }
}