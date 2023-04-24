using webapplication.core.Entity.Abstract;
using webapplication.entity.Identity;
namespace webapplication.entity.Menu
{
    public class Menu : IEntity
    {
        public int MenuId { get; set; }
        public string MenuText { get; set; } = "";
        public string MenuKeyword { get; set; } = "";
        public string MenuHref { get; set; } = "";
        public string MenuIconPath { get; set; } = "";
        public int MenuHeaderId { get; set; }
        public MenuHeader? MenuHeader { get; set; }
        public int? ApplicationRoleId { get; set; }
        public ApplicationRole? ApplicationRole { get; set; }
        public bool Passive { get; set; } = false;
    }
}