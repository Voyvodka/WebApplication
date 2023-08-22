using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class ModuleManager : BaseCrudManager<Module>, IModuleService
    {
        public ModuleManager(IModuleDal entityDal) : base(entityDal)
        {
        }
    }
}