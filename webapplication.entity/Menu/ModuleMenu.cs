using webapplication.core.Entity.Abstract;
namespace webapplication.entity
{
    public class ModuleMenu : IEntity
    {
        public int ModuleMenuId { get; set; }
        public int MenuId { get; set; }
        public Menu? Menu { get; set; }
        public int ModuleId { get; set; }
        public Module? Module { get; set; }
    }
}