using webapplication.core.Entity.Abstract;
namespace webapplication.entity.Identity
{
    public class RoleGroupRole : IEntity
    {
        public int RoleGroupRoleId { get; set; }
        public int RoleGroupId { get; set; }
        public string ApplicationRoleId { get; set; }
        public RoleGroup RoleGroup { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}