using webapplication.entity.Identity;
using webapplication.entity.Location;
namespace webapplication.webui.ViewModels
{
    public class AccountViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Country> Countries { get; set; }
    }
}