using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity;
namespace webapplication.business.Concrete
{
    public class MenuManager : IMenuService
    {
        private readonly IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }
        public IResult Add(Menu menu)
        {
            _menuDal.Add(menu);
            return new SuccessResult();
        }
        public IResult Delete(Menu menu)
        {
            _menuDal.Delete(menu);
            return new SuccessResult();
        }
        public IDataResult<List<Menu>> GetAll(Expression<Func<Menu, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<Menu>>(_menuDal.GetList());
            }
            return new SuccessDataResult<List<Menu>>(_menuDal.GetList(expression));
        }
        public IDataResult<Menu> GetSingle(Expression<Func<Menu, bool>> expression)
        {
            return new SuccessDataResult<Menu>(_menuDal.Get(expression));
        }
        public IResult Update(Menu menu)
        {
            _menuDal.Update(menu);
            return new SuccessResult();
        }
    }
}