using webapplication.core.Entity.Abstract;
namespace webapplication.entity.Menu
{
    public class MenuModule : IEntity
    {
        public int MenuModuleId { get; set; }
        public string MenuModuleText { get; set; } = "";
        public string MenuModuleIconPath { get; set; } = "";
        public bool Passive { get; set; } = false;
    }
}