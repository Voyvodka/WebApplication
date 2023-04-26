using webapplication.core.Entity.Abstract;
namespace webapplication.entity.Menu
{
    public class ModuleMenu : IEntity
    {
        public int MenuId { get; set; }
        public Menu? Menu { get; set; }
        public int MenuModuleId { get; set; }
        public MenuModule? MenuModule { get; set; }
    }
}