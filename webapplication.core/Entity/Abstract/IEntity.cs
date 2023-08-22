namespace webapplication.core.Entity.Abstract
{
    public class IEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsPassive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
