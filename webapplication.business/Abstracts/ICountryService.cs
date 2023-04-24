using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity.Location;
namespace webapplication.business.Abstracts
{
    public interface ICountryService
    {
        public IDataResult<List<Country>> GetAll(Expression<Func<Country, bool>>? expression = null);
        public IDataResult<Country> GetSingle(Expression<Func<Country, bool>> expression);
        public IResult Add(Country country);
        public IResult Update(Country country);
        public IResult Delete(Country country);
    }
}