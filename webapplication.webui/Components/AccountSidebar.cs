using Microsoft.AspNetCore.Mvc;

namespace webapplication.webui.Components
{
    public class AccountSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("_AccountSidebar");
        }
    }
}