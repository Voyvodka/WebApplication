using webapplication.entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapplication.entity.Location;
using webapplication.entity;
namespace webapplication.dataaccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<MenuHeader> MenuHeaders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ModuleMenu> ModuleMenus { get; set; }
        public DbSet<AdminModule> AdminModules { get; set; }
        public DbSet<AdminMenuHeader> AdminMenuHeaders { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<AdminModuleMenu> AdminModuleMenus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion version = new MySqlServerVersion(new Version(8, 0, 32));
            optionsBuilder.UseMySql(@"Server=localhost;port=3306;Database=webapplication;Uid=root;Pwd=1234;charset=utf8", version);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}