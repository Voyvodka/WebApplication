using webapplication.core.Entity.Abstract;
using webapplication.entity.Identity;
namespace webapplication.entity
{
    public class AdminMenu : IEntity
    {
        public int AdminMenuId { get; set; }
        public string AdminMenuText { get; set; } = "";
        public string AdminMenuKeyword { get; set; } = "";
        public string AdminMenuHref { get; set; } = "";
        public string AdminMenuIconPath { get; set; } = "";
        public int AdminMenuHeaderId { get; set; }
        public AdminMenuHeader? AdminMenuHeader { get; set; }
        public string? ApplicationRoleId { get; set; }
        public ApplicationRole? ApplicationRole { get; set; }
        public bool Passive { get; set; } = false;
    }
}