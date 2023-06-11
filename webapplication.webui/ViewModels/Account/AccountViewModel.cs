using webapplication.entity;
using webapplication.entity.Identity;
namespace webapplication.webui.ViewModels
{
    public class AccountViewModel
    {
        public ApplicationUser? User { get; set; }
        public List<Country>? Countries { get; set; }
    }
}