using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminMenuHeaderManager : IAdminMenuHeaderService
    {
        private readonly IAdminMenuHeaderDal _adminMenuHeaderDal;
        public AdminMenuHeaderManager(IAdminMenuHeaderDal adminMenuHeaderDal)
        {
            _adminMenuHeaderDal = adminMenuHeaderDal;
        }
        public IResult Add(AdminMenuHeader adminMenuHeader)
        {
            _adminMenuHeaderDal.Add(adminMenuHeader);
            return new SuccessResult();
        }
        public IResult Delete(AdminMenuHeader adminMenuHeader)
        {
            _adminMenuHeaderDal.Delete(adminMenuHeader);
            return new SuccessResult();
        }
        public IDataResult<List<AdminMenuHeader>> GetAll(Expression<Func<AdminMenuHeader, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<AdminMenuHeader>>(_adminMenuHeaderDal.GetList());
            }
            return new SuccessDataResult<List<AdminMenuHeader>>(_adminMenuHeaderDal.GetList(expression));
        }
        public IDataResult<AdminMenuHeader> GetSingle(Expression<Func<AdminMenuHeader, bool>> expression)
        {
            return new SuccessDataResult<AdminMenuHeader>(_adminMenuHeaderDal.Get(expression));
        }
        public IResult Update(AdminMenuHeader adminMenuHeader)
        {
            _adminMenuHeaderDal.Update(adminMenuHeader);
            return new SuccessResult();
        }
    }
}