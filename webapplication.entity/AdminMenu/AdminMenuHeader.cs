using webapplication.core.Entity.Abstract;
namespace webapplication.entity
{
    public class AdminMenuHeader : IEntity
    {
        public int AdminMenuHeaderId { get; set; }
        public string AdminMenuHeaderText { get; set; } = "";
        public string AdminMenuHeaderIconPath { get; set; } = "";
        public bool Passive { get; set; } = false;
    }
}