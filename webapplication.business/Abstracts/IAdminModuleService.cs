using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity;
namespace webapplication.business.Abstracts
{
    public interface IAdminModuleService
    {
        public IDataResult<List<AdminModule>> GetAll(Expression<Func<AdminModule, bool>>? expression = null);
        public IDataResult<AdminModule> GetSingle(Expression<Func<AdminModule, bool>> expression);
        public IResult Add(AdminModule adminModule);
        public IResult Update(AdminModule adminModule);
        public IResult Delete(AdminModule adminModule);
    }
}