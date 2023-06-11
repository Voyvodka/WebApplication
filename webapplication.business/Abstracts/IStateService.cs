using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity;
namespace webapplication.business.Abstracts
{
    public interface IStateService
    {
        public IDataResult<List<State>> GetAll(Expression<Func<State, bool>>? expression = null);
        public IDataResult<State> GetSingle(Expression<Func<State, bool>> expression);
        public IResult Add(State state);
        public IResult Update(State state);
        public IResult Delete(State state);
    }
}