using webapplication.core.Entity.Abstract;
namespace webapplication.entity.Identity
{
    public class RoleGroup : IEntity
    {
        public int RoleGroupId { get; set; }
        public string Name { get; set; } = "";
        public string NormalizedName { get; set; } = "";
    }
}