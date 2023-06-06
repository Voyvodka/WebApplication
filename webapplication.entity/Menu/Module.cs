using webapplication.core.Entity.Abstract;
namespace webapplication.entity
{
    public class Module : IEntity
    {
        public int ModuleId { get; set; }
        public string ModuleText { get; set; } = "";
        public string ModuleIconPath { get; set; } = "";
        public bool Passive { get; set; } = false;
    }
}