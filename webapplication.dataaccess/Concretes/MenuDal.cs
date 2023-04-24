using webapplication.core.DataAccess.EntityFramework;
using webapplication.dataaccess.Abstracts;
using webapplication.dataaccess.Contexts;
using webapplication.entity.Menu;
namespace webapplication.dataaccess.Concretes
{
    public class MenuDal : EfEntityRepositoryBase<Menu, ApplicationDbContext>, IMenuDal
    {
    }
}