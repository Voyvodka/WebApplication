using webapplication.core.Entity.Abstract;
namespace webapplication.entity
{
    public class AdminModule : IEntity
    {
        public int AdminModuleId { get; set; }
        public string AdminModuleText { get; set; } = "";
        public string AdminModuleIconPath { get; set; } = "";
        public bool Passive { get; set; } = false;
    }
}