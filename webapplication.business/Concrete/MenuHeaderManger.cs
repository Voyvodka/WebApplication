using webapplication.business.Abstracts;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class MenuHeaderManager : BaseCrudManager<MenuHeader>, IMenuHeaderService
    {
        public MenuHeaderManager(IMenuHeaderDal entityDal) : base(entityDal)
        {
        }
    }
}