using webapplication.core.Entity.Abstract;
namespace webapplication.entity.Location
{
    public class State : IEntity
    {
        public int id { get; set; }
        public string name { get; set; } = "";
        public int country_id { get; set; }
        public Country? Country { get; set; }
        public char country_code { get; set; }
    }
}