using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class ModuleMenuManager : BaseCrudManager<ModuleMenu>, IModuleMenuService
    {
        public ModuleMenuManager(IModuleMenuDal entityDal) : base(entityDal)
        {
        }
    }
}