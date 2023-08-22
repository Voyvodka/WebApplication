using webapplication.business.Abstracts;
using webapplication.entity;
using webapplication.dataaccess.Abstracts;
namespace webapplication.business.Concrete
{
    public class CountryManager : BaseCrudManager<Country>, ICountryService
    {
        public CountryManager(ICountryDal entityDal) : base(entityDal)
        {
        }
    }
}