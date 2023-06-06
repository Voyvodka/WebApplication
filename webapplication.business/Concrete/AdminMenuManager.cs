using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminMenuManager : IAdminMenuService
    {
        private readonly IAdminMenuDal _adminMenuDal;
        public AdminMenuManager(IAdminMenuDal adminMenuDal)
        {
            _adminMenuDal = adminMenuDal;
        }
        public IResult Add(AdminMenu adminMenu)
        {
            _adminMenuDal.Add(adminMenu);
            return new SuccessResult();
        }
        public IResult Delete(AdminMenu adminMenu)
        {
            _adminMenuDal.Delete(adminMenu);
            return new SuccessResult();
        }
        public IDataResult<List<AdminMenu>> GetAll(Expression<Func<AdminMenu, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<AdminMenu>>(_adminMenuDal.GetList());
            }
            return new SuccessDataResult<List<AdminMenu>>(_adminMenuDal.GetList(expression));
        }
        public IDataResult<AdminMenu> GetSingle(Expression<Func<AdminMenu, bool>> expression)
        {
            return new SuccessDataResult<AdminMenu>(_adminMenuDal.Get(expression));
        }
        public IResult Update(AdminMenu adminMenu)
        {
            _adminMenuDal.Update(adminMenu);
            return new SuccessResult();
        }
    }
}