using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminMenuHeaderManager : BaseCrudManager<AdminMenuHeader>, IAdminMenuHeaderService
    {
        public AdminMenuHeaderManager(IAdminMenuHeaderDal entityDal) : base(entityDal)
        {
        }
    }
}