using webapplication.entity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using webapplication.webui.ViewModels;
namespace webapplication.webui.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _signInManager = signinManager;
        }
        public async Task<IActionResult> Logout()
        {
            ViewData["Title"] = "Çıkış yapılıyor...";
            await _signInManager.SignOutAsync();
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
                var result = await _signInManager.PasswordSignInAsync(user.UserName, p.Password, p.RememberMe, true);
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
        public IActionResult GoogleLogin(string returnUrl)
        {
            var redirectUrl = Url.Action(nameof(GoogleCallback), "Auth", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return Challenge(properties, "Google");
        }
        public async Task<IActionResult> GoogleCallback(string returnUrl = "/")
        {
            var loginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction(nameof(Login));
            }
            var signInResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            var userEmail = loginInfo.Principal.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
            {
                var firstName = loginInfo.Principal.FindFirstValue(ClaimTypes.GivenName);
                var lastName = loginInfo.Principal.FindFirstValue(ClaimTypes.Surname);
                var username = loginInfo.Principal.FindFirstValue(ClaimTypes.Name) ?? userEmail.Split('@')[0];
                user = new ApplicationUser
                {
                    UserName = username,
                    Email = userEmail,
                    FirstName = firstName,
                    LastName = lastName,
                };
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            return LocalRedirect(returnUrl);
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