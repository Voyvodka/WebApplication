using webapplication.core.DataAccess.EntityFramework;
using webapplication.dataaccess.Abstracts;
using webapplication.dataaccess.Contexts;
using webapplication.entity.Location;
namespace webapplication.dataaccess.Concretes
{
    public class CityDal : EfEntityRepositoryBase<City, ApplicationDbContext>, ICityDal
    {
    }
}