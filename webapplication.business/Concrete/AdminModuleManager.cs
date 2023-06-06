using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminModuleManager : IAdminModuleService
    {
        private readonly IAdminModuleDal _adminModuleDal;
        public AdminModuleManager(IAdminModuleDal adminModuleDal)
        {
            _adminModuleDal = adminModuleDal;
        }
        public IResult Add(AdminModule adminModule)
        {
            _adminModuleDal.Add(adminModule);
            return new SuccessResult();
        }
        public IResult Delete(AdminModule adminModule)
        {
            _adminModuleDal.Delete(adminModule);
            return new SuccessResult();
        }
        public IDataResult<List<AdminModule>> GetAll(Expression<Func<AdminModule, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<AdminModule>>(_adminModuleDal.GetList());
            }
            return new SuccessDataResult<List<AdminModule>>(_adminModuleDal.GetList(expression));
        }
        public IDataResult<AdminModule> GetSingle(Expression<Func<AdminModule, bool>> expression)
        {
            return new SuccessDataResult<AdminModule>(_adminModuleDal.Get(expression));
        }
        public IResult Update(AdminModule adminModule)
        {
            _adminModuleDal.Update(adminModule);
            return new SuccessResult();
        }
    }
}