using webapplication.entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapplication.webui.ViewModels;
namespace webapplication.webui.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<IActionResult> Logout()
        {
            ViewData["Title"] = "Çıkış yapılıyor...";
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewData["Title"] = "Giriş";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserSignInViewModel p)
        {
            ViewData["LoginResult"] = "";
            ViewData["Title"] = "Giriş Yapılıyor";
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(p.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                    return View(p);
                }
                var result = await _signinManager.PasswordSignInAsync(user.UserName, p.Password, p.RememberMe, true);
                if (result.Succeeded)
                {
                    string returnUrl = HttpContext.Request.Query["ReturnUrl"];
                    if (returnUrl == null)
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
                else
                {
                    return View(p);
                }
            }
            else
            {
                return View(p);
            }
        }
        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action(nameof(GoogleCallback), "Auth");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        public async Task<IActionResult> GoogleCallback()
        {
            var result = HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme).Result;
            if (!result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            if (email == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                var name = result.Principal.FindFirstValue(ClaimTypes.Name);
                var newUser = new ApplicationUser { UserName = email, Email = email, Name = "", LastName = "" };
                if (name != null)
                {
                    var nameParts = name.Split(' ');
                    if (nameParts.Length > 0)
                    {
                        newUser.Name = nameParts[0];
                    }
                    if (nameParts.Length > 1)
                    {
                        newUser.LastName = nameParts[1];
                    }
                }
                var createResult = await _userManager.CreateAsync(newUser);
                if (!createResult.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
                user = newUser;
            }
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            var authProperties = new AuthenticationProperties();
            authProperties.IsPersistent = true;
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authProperties).Wait();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kullanıcı Kayıt";
            var model = new UserSignUpViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserSignUpViewModel p)
        {
            ViewData["Title"] = "Kayıt ediliyor..";
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = p.Email,
                    UserName = p.Username,
                };
                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
    }
}