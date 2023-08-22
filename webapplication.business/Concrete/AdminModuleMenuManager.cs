using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminModuleMenuManager : BaseCrudManager<AdminModuleMenu>, IAdminModuleMenuService
    {
        public AdminModuleMenuManager(IAdminModuleMenuDal entityDal) : base(entityDal)
        {
        }
    }
}