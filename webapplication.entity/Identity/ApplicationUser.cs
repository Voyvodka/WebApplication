using Microsoft.AspNetCore.Identity;
namespace webapplication.entity.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? ImagePath { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
    }
}