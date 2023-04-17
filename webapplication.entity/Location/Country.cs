using webapplication.core.Entity.Abstract;
namespace webapplication.entity.Location
{
    public class Country : IEntity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? phonecode { get; set; }
        public string? capital { get; set; }
        public string? currency { get; set; }
        public string? currency_symbol { get; set; }
        public string? region { get; set; }
    }
}