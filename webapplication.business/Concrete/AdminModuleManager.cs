using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class AdminModuleManager : BaseCrudManager<AdminModule>, IAdminModuleService
    {
        public AdminModuleManager(IAdminModuleDal entityDal) : base(entityDal)
        {
        }
    }
}