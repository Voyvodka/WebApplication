using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity;
namespace webapplication.business.Abstracts
{
    public interface IAdminModuleMenuService
    {
        public IDataResult<List<AdminModuleMenu>> GetAll(Expression<Func<AdminModuleMenu, bool>>? expression = null);
        public IDataResult<AdminModuleMenu> GetSingle(Expression<Func<AdminModuleMenu, bool>> expression);
        public IResult Add(AdminModuleMenu adminModuleMenu);
        public IResult Update(AdminModuleMenu adminModuleMenu);
        public IResult Delete(AdminModuleMenu adminModuleMenu);
    }
}