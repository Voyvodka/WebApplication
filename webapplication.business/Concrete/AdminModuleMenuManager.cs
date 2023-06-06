using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminModuleMenuManager : IAdminModuleMenuService
    {
        private readonly IAdminModuleMenuDal _adminModuleMenuDal;
        public AdminModuleMenuManager(IAdminModuleMenuDal adminModuleMenuDal)
        {
            _adminModuleMenuDal = adminModuleMenuDal;
        }
        public IResult Add(AdminModuleMenu adminModuleMenu)
        {
            _adminModuleMenuDal.Add(adminModuleMenu);
            return new SuccessResult();
        }
        public IResult Delete(AdminModuleMenu adminModuleMenu)
        {
            _adminModuleMenuDal.Delete(adminModuleMenu);
            return new SuccessResult();
        }
        public IDataResult<List<AdminModuleMenu>> GetAll(Expression<Func<AdminModuleMenu, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<AdminModuleMenu>>(_adminModuleMenuDal.GetList());
            }
            return new SuccessDataResult<List<AdminModuleMenu>>(_adminModuleMenuDal.GetList(expression));
        }
        public IDataResult<AdminModuleMenu> GetSingle(Expression<Func<AdminModuleMenu, bool>> expression)
        {
            return new SuccessDataResult<AdminModuleMenu>(_adminModuleMenuDal.Get(expression));
        }
        public IResult Update(AdminModuleMenu adminModuleMenu)
        {
            _adminModuleMenuDal.Update(adminModuleMenu);
            return new SuccessResult();
        }
    }
}