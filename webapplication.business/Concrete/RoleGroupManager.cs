using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Identity;
namespace webapplication.business.Concrete
{
    public class RoleGroupManager : IRoleGroupService
    {
        private readonly IRoleGroupDal _roleGroupDal;
        public RoleGroupManager(IRoleGroupDal roleGroupDal)
        {
            _roleGroupDal = roleGroupDal;
        }
        public IResult Add(RoleGroup roleGroup)
        {
            _roleGroupDal.Add(roleGroup);
            return new SuccessResult();
        }
        public IResult Delete(RoleGroup roleGroup)
        {
            _roleGroupDal.Delete(roleGroup);
            return new SuccessResult();
        }
        public IDataResult<List<RoleGroup>> GetAll(Expression<Func<RoleGroup, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<RoleGroup>>(_roleGroupDal.GetList());
            }
            return new SuccessDataResult<List<RoleGroup>>(_roleGroupDal.GetList(expression));
        }
        public IDataResult<RoleGroup> GetSingle(Expression<Func<RoleGroup, bool>> expression)
        {
            return new SuccessDataResult<RoleGroup>(_roleGroupDal.Get(expression));
        }
        public IResult Update(RoleGroup roleGroup)
        {
            _roleGroupDal.Update(roleGroup);
            return new SuccessResult();
        }
    }
}