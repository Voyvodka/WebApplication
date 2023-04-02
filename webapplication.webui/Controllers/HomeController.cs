using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace webapplication.webui.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Ana Sayfa";
            return View();
        }
        public IActionResult About()
        {
            ViewData["Title"] = "Hakkımızda";
            return View();
        }
    }
}