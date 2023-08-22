using webapplication.business.Abstracts;
using webapplication.entity;
using webapplication.dataaccess.Abstracts;
namespace webapplication.business.Concrete
{
    public class CityManager : BaseCrudManager<City>, ICityService
    {
        public CityManager(ICityDal entityDal) : base(entityDal)
        {
        }
    }
}