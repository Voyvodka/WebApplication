using System.Linq.Expressions;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Results;
using webapplication.entity;
using webapplication.dataaccess.Abstracts;
namespace webapplication.business.Concrete
{
    public class StateManager : IStateService
    {
        private readonly IStateDal _stateDal;
        public StateManager(IStateDal stateDal)
        {
            _stateDal = stateDal;
        }
        public IResult Add(State state)
        {
            _stateDal.Add(state);
            return new SuccessResult();
        }
        public IResult Delete(State state)
        {
            _stateDal.Delete(state);
            return new SuccessResult();
        }
        public IDataResult<List<State>> GetAll(Expression<Func<State, bool>>? expression = null)
        {
            if (expression == null)
            {
                return new SuccessDataResult<List<State>>(_stateDal.GetList());
            }
            return new SuccessDataResult<List<State>>(_stateDal.GetList(expression));
        }
        public IDataResult<State> GetSingle(Expression<Func<State, bool>> expression)
        {
            return new SuccessDataResult<State>(_stateDal.Get(expression));
        }
        public IResult Update(State state)
        {
            _stateDal.Update(state);
            return new SuccessResult();
        }
    }
}