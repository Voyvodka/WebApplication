using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.entity.Location;
using webapplication.dataaccess.Abstracts;
namespace webapplication.business.Concrete
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public IResult Add(City city)
        {
            _cityDal.Add(city);
            return new SuccessResult();
        }
        public IResult Delete(City city)
        {
            _cityDal.Delete(city);
            return new SuccessResult();
        }
        public IDataResult<List<City>> GetAll(Expression<Func<City, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<City>>(_cityDal.GetList());
            }
            return new SuccessDataResult<List<City>>(_cityDal.GetList(expression));
        }
        public IDataResult<City> GetSingle(Expression<Func<City, bool>> expression)
        {
            return new SuccessDataResult<City>(_cityDal.Get(expression));
        }
        public IResult Update(City city)
        {
            _cityDal.Update(city);
            return new SuccessResult();
        }
    }
}