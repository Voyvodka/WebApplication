using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminMenuManager : BaseCrudManager<AdminMenu>, IAdminMenuService
    {
        public AdminMenuManager(IAdminMenuDal entityDal) : base(entityDal)
        {
        }
    }
}