using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapplication.business.Abstracts;
using webapplication.entity.Identity;
using webapplication.entity.Menu;
using Microsoft.EntityFrameworkCore;
namespace webapplication.webui.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMenuService _menuService;
        private readonly IMenuHeaderService _menuHeaderService;
        private readonly IMenuModuleService _menuModuleService;
        private readonly IModuleMenuService _moduleMenuService;
        private readonly IFileService _fileService;
        public ManagementController(RoleManager<ApplicationRole> roleManager, IFileService fileService, IMenuService menuService, IMenuHeaderService menuHeaderService, IMenuModuleService menuModuleService, IModuleMenuService moduleMenuService, UserManager<ApplicationUser> userManager)
        {
            _fileService = fileService;
            _menuService = menuService;
            _menuHeaderService = menuHeaderService;
            _menuModuleService = menuModuleService;
            _moduleMenuService = moduleMenuService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Ana Sayfa";
            return View();
        }
        public IActionResult CreateMenu()
        {
            ViewData["Title"] = "Menu Tanımlamaları";
            return View();
        }
        public bool SaveModuleMenu(MenuModule menuModule, IFormFile file)
        {
            if (String.IsNullOrEmpty(menuModule.MenuModuleText)) return false;
            _menuModuleService.Add(menuModule);
            if (file != null) _fileService.AddForMenuModule(file, menuModule);
            return true;
        }
        public bool SaveModuleHeader(MenuHeader menuHeader, IFormFile file)
        {
            if (String.IsNullOrEmpty(menuHeader.MenuHeaderText)) return false;
            _menuHeaderService.Add(menuHeader);
            if (file != null) _fileService.AddForMenuHeader(file, menuHeader);
            return true;
        }
        public List<MenuHeader> GetMenuHeaders() => _menuHeaderService.GetAll().Data;
        public async Task<List<ApplicationRole>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }
    }
}