using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Identity;
namespace webapplication.business.Concrete
{
    public class RoleGroupManager : BaseCrudManager<RoleGroup>, IRoleGroupService
    {
        public RoleGroupManager(IRoleGroupDal entityDal) : base(entityDal)
        {
        }
    }
}