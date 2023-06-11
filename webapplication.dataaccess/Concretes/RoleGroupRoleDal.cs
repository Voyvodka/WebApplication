using webapplication.core.DataAccess.EntityFramework;
using webapplication.dataaccess.Abstracts;
using webapplication.dataaccess.Contexts;
using webapplication.entity.Identity;
namespace webapplication.dataaccess.Concretes
{
    public class RoleGroupRoleDal : EfEntityRepositoryBase<RoleGroupRole, ApplicationDbContext>, IRoleGroupRoleDal
    {
    }
}