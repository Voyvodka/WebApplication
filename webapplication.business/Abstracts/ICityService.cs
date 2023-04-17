using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity.Location;
namespace webapplication.business.Abstracts
{
    public interface ICityService
    {
        public IDataResult<List<City>> GetAll(Expression<Func<City, bool>> expression = null);
        public IDataResult<City> GetSingle(Expression<Func<City, bool>> expression);
        public IResult Add(City city);
        public IResult Update(City city);
        public IResult Delete(City city);
    }
}