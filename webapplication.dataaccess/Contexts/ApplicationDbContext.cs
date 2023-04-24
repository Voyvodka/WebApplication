using webapplication.entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapplication.entity.Location;
using webapplication.entity.Menu;
namespace webapplication.dataaccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<MenuModule> MenuModules { get; set; }
        public DbSet<MenuHeader> MenuHeaders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion version = new MySqlServerVersion(new Version(8, 0, 32));
            optionsBuilder.UseMySql(@"Server=localhost;port=3306;Database=webapplication;Uid=root;Pwd=1234;charset=utf8", version);
            base.OnConfiguring(optionsBuilder);
        }
    }
}