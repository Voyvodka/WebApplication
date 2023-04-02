using webapplication.entity.Identity;
using webapplication.webui.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace webapplication.webui.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Profilim";
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return View();
            var model = new AccountViewModel
            {
                User = user,
            };
            return View(model);
        }
        public async Task<IActionResult> Settings()
        {
            ViewData["Title"] = "Profil Ayarları";
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new AccountViewModel
            {
                User = user,
            };
            return View(model);
        }
    }
}