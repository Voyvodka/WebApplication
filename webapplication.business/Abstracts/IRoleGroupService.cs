using System.Linq.Expressions;
using webapplication.core.Utilities.Results;
using webapplication.entity.Identity;
namespace webapplication.business.Abstracts
{
    public interface IRoleGroupService
    {
        public IDataResult<List<RoleGroup>> GetAll(Expression<Func<RoleGroup, bool>>? expression = null);
        public IDataResult<RoleGroup> GetSingle(Expression<Func<RoleGroup, bool>> expression);
        public IResult Add(RoleGroup roleGroup);
        public IResult Update(RoleGroup roleGroup);
        public IResult Delete(RoleGroup roleGroup);
    }
}