using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class MenuManager : BaseCrudManager<Menu>, IMenuService
    {
        public MenuManager(IMenuDal entityDal) : base(entityDal)
        {
        }
    }
}