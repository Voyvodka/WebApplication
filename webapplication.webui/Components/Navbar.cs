using webapplication.entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapplication.webui.ViewModels;

namespace webapplication.webui.Components
{
    [ViewComponent]
    public class Navbar : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public Navbar(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            NavbarViewModel model = new();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
                model.User = user;
            return View("_Navbar", model);
        }
    }
}