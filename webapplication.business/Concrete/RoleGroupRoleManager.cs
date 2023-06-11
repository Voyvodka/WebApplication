using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Identity;
namespace webapplication.business.Concrete
{
    public class RoleGroupRoleManager : IRoleGroupRoleService
    {
        private readonly IRoleGroupRoleDal _roleGroupRoleDal;
        public RoleGroupRoleManager(IRoleGroupRoleDal roleGroupRoleDal)
        {
            _roleGroupRoleDal = roleGroupRoleDal;
        }
        public IResult Add(RoleGroupRole roleGroupRole)
        {
            _roleGroupRoleDal.Add(roleGroupRole);
            return new SuccessResult();
        }
        public IResult Delete(RoleGroupRole roleGroupRole)
        {
            _roleGroupRoleDal.Delete(roleGroupRole);
            return new SuccessResult();
        }
        public IDataResult<List<RoleGroupRole>> GetAll(Expression<Func<RoleGroupRole, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<RoleGroupRole>>(_roleGroupRoleDal.GetList());
            }
            return new SuccessDataResult<List<RoleGroupRole>>(_roleGroupRoleDal.GetList(expression));
        }
        public IDataResult<RoleGroupRole> GetSingle(Expression<Func<RoleGroupRole, bool>> expression)
        {
            return new SuccessDataResult<RoleGroupRole>(_roleGroupRoleDal.Get(expression));
        }
        public IResult Update(RoleGroupRole roleGroupRole)
        {
            _roleGroupRoleDal.Update(roleGroupRole);
            return new SuccessResult();
        }
    }
}