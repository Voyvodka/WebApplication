using webapplication.entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace webapplication.dataaccess.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ServerVersion version = new MySqlServerVersion(new Version(8, 0, 32));
            optionsBuilder.UseMySql(@"Server=localhost;port=3306;Database=webapplication;Uid=root;Pwd=1234;charset=utf8", version);
            base.OnConfiguring(optionsBuilder);
        }
    }
}