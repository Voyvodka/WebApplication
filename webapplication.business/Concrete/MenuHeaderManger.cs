using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.dataaccess.Abstracts;
using webapplication.entity.Menu;
namespace webapplication.business.Concrete
{
    public class MenuHeaderManager : IMenuHeaderService
    {
        private readonly IMenuHeaderDal _menuHeaderDal;
        public MenuHeaderManager(IMenuHeaderDal menuHeaderDal)
        {
            _menuHeaderDal = menuHeaderDal;
        }
        public IResult Add(MenuHeader menuHeader)
        {
            _menuHeaderDal.Add(menuHeader);
            return new SuccessResult();
        }
        public IResult Delete(MenuHeader menuHeader)
        {
            _menuHeaderDal.Delete(menuHeader);
            return new SuccessResult();
        }
        public IDataResult<List<MenuHeader>> GetAll(Expression<Func<MenuHeader, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<MenuHeader>>(_menuHeaderDal.GetList());
            }
            return new SuccessDataResult<List<MenuHeader>>(_menuHeaderDal.GetList(expression));
        }
        public IDataResult<MenuHeader> GetSingle(Expression<Func<MenuHeader, bool>> expression)
        {
            return new SuccessDataResult<MenuHeader>(_menuHeaderDal.Get(expression));
        }
        public IResult Update(MenuHeader menuHeader)
        {
            _menuHeaderDal.Update(menuHeader);
            return new SuccessResult();
        }
    }
}