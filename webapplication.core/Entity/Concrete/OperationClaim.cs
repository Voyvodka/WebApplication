using webapplication.core.Entity.Abstract;

namespace webapplication.core.Entity.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
