using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity.Identity;
namespace webapplication.business.Abstracts
{
    public interface IRoleGroupRoleService
    {
        public IDataResult<List<RoleGroupRole>> GetAll(Expression<Func<RoleGroupRole, bool>>? expression = null);
        public IDataResult<RoleGroupRole> GetSingle(Expression<Func<RoleGroupRole, bool>> expression);
        public IResult Add(RoleGroupRole roleGroupRole);
        public IResult Update(RoleGroupRole roleGroupRole);
        public IResult Delete(RoleGroupRole roleGroupRole);
    }
}