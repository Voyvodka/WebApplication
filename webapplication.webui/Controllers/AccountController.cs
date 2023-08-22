using webapplication.entity.Identity;
using webapplication.webui.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapplication.business.Abstracts;
namespace webapplication.webui.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly ICountryService _countryService;
        private readonly ICityService _cityService;
        private readonly IStateService _stateService;
        public AccountController(ICountryService countryService, ICityService cityService, IStateService stateService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _countryService = countryService;
            _cityService = cityService;
            _stateService = stateService;
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
                Countries = _countryService.GetList(),
            };
            return View(model);
        }
    }
}