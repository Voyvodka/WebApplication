using webapplication.entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapplication.entity.Location;
namespace webapplication.dataaccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<State> states { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion version = new MySqlServerVersion(new Version(8, 0, 32));
            optionsBuilder.UseMySql(@"Server=localhost;port=3306;Database=webapplication;Uid=root;Pwd=1234;charset=utf8", version);
            base.OnConfiguring(optionsBuilder);
        }
    }
}