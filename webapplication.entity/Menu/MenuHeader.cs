using webapplication.core.Entity.Abstract;
namespace webapplication.entity.Menu
{
    public class MenuHeader : IEntity
    {
        public int MenuHeaderId { get; set; }
        public string MenuHeaderText { get; set; } = "";
        public int MenuModuleId { get; set; }
        public MenuModule? MenuModule { get; set; }
        public string MenuHeaderIconPath { get; set; } = "";
        public bool Passive { get; set; } = false;
    }
}