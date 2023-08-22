using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Identity;
namespace webapplication.business.Concrete
{
    public class RoleGroupRoleManager : BaseCrudManager<RoleGroupRole>, IRoleGroupRoleService
    {
        public RoleGroupRoleManager(IRoleGroupRoleDal entityDal) : base(entityDal)
        {
        }
    }
}