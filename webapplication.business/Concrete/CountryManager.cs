using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.entity.Location;
using webapplication.dataaccess.Abstracts;
namespace webapplication.business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;
        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }
        public IResult Add(Country country)
        {
            _countryDal.Add(country);
            return new SuccessResult();
        }
        public IResult Delete(Country country)
        {
            _countryDal.Delete(country);
            return new SuccessResult();
        }
        public IDataResult<List<Country>> GetAll(Expression<Func<Country, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Country>>(_countryDal.GetList());
            }
            return new SuccessDataResult<List<Country>>(_countryDal.GetList(expression));
        }
        public IDataResult<Country> GetSingle(Expression<Func<Country, bool>> expression)
        {
            return new SuccessDataResult<Country>(_countryDal.Get(expression));
        }
        public IResult Update(Country country)
        {
            _countryDal.Update(country);
            return new SuccessResult();
        }
    }
}