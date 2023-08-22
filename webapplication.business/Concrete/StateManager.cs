using webapplication.business.Abstracts;
using webapplication.entity;
using webapplication.dataaccess.Abstracts;
namespace webapplication.business.Concrete
{
    public class StateManager : BaseCrudManager<State>, IStateService
    {
        public StateManager(IStateDal entityDal) : base(entityDal)
        {
        }
    }
}