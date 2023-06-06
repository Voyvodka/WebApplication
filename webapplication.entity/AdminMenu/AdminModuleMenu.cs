using webapplication.core.Entity.Abstract;
namespace webapplication.entity
{
    public class AdminModuleMenu : IEntity
    {
        public int AdminModuleMenuId { get; set; }
        public int AdminMenuId { get; set; }
        public AdminMenu? AdminMenu { get; set; }
        public int AdminModuleId { get; set; }
        public AdminModule? AdminModule { get; set; }
    }
}