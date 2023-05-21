using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapplication.business.Abstracts;
using webapplication.entity.Identity;
using webapplication.entity.Menu;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace webapplication.webui.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMenuService _menuService;
        private readonly IMenuHeaderService _menuHeaderService;
        private readonly IModuleService _moduleService;
        private readonly IModuleMenuService _moduleMenuService;
        private readonly IFileService _fileService;
        public ManagementController(RoleManager<ApplicationRole> roleManager, IFileService fileService, IMenuService menuService, IMenuHeaderService menuHeaderService, IModuleService moduleService, IModuleMenuService moduleMenuService, UserManager<ApplicationUser> userManager)
        {
            _fileService = fileService;
            _menuService = menuService;
            _menuHeaderService = menuHeaderService;
            _moduleService = moduleService;
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
        [HttpPost]
        public bool SaveModule(Module module)
        {
            if (String.IsNullOrEmpty(module.ModuleText)) return false;
            _moduleService.Add(module);
            return true;
        }
        public bool SaveMenuHeader(MenuHeader menuHeader)
        {
            if (String.IsNullOrEmpty(menuHeader.MenuHeaderText)) return false;
            _menuHeaderService.Add(menuHeader);
            return true;
        }
        public async Task<List<ApplicationRole>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }
        [HttpPost]
        public bool SaveMenu(Menu menu)
        {
            var keywords = JsonConvert.DeserializeObject<dynamic[]>(menu.MenuKeyword);
            menu.MenuKeyword = "";
            if (keywords != null)
            {
                for (var i = 0; i < keywords.Length; i++)
                {
                    menu.MenuKeyword += keywords[i].value + "~";
                }
            }
            if (String.IsNullOrEmpty(menu.MenuText)) return false;
            _menuService.Add(menu);
            return true;
        }
        public object GetModuleMenus()
        {
            var data = new
            {
                moduleMenus = _moduleMenuService.GetAll().Data,
                modules = _moduleService.GetAll().Data,
            };
            data.moduleMenus.ForEach(item =>
            {
                item.Menu = _menuService.GetSingle(c => c.MenuId == item.MenuId).Data;
                item.Menu.MenuHeader = _menuHeaderService.GetSingle(c => c.MenuHeaderId == item.Menu.MenuHeaderId).Data;
            });
            return data;
        }
        [HttpPost]
        public bool AddMenuToModule(int moduleId, int menuId)
        {
            var module = _moduleService.GetSingle(c => c.ModuleId == moduleId).Data;
            var menu = _menuService.GetSingle(c => c.MenuId == menuId).Data;
            if (menu == null || module == null || _moduleMenuService.GetAll(c => c.ModuleId == moduleId && c.MenuId == menuId).Data.Any()) return false;
            _moduleMenuService.Add(new ModuleMenu
            {
                MenuId = menuId,
                ModuleId = moduleId
            });
            return true;
        }
        [HttpPost]
        public bool RemoveModuleMenus(int moduleId, int menuId, int moduleMenuId)
        {
            var module = _moduleService.GetSingle(c => c.ModuleId == moduleId).Data;
            var menu = _menuService.GetSingle(c => c.MenuId == menuId).Data;
            var moduleMenu = _moduleMenuService.GetSingle(c => c.ModuleMenuId == moduleMenuId).Data;
            if (module == null || menu == null || moduleMenu == null) return false;
            if (moduleMenu.ModuleId != module.ModuleId && moduleMenu.MenuId != menu.MenuId) return false;
            _moduleMenuService.Delete(moduleMenu);
            return true;
        }
        public bool UpdateModule(int moduleId, string moduleText, string moduleIcon)
        {
            var module = _moduleService.GetSingle(c => c.ModuleId == moduleId).Data;
            if (module == null || String.IsNullOrEmpty(moduleText)) return false;
            module.ModuleText = moduleText;
            module.ModuleIconPath = moduleIcon;
            _moduleService.Update(module);
            return true;
        }
        public bool UpdateMenuHeader(int menuHeaderId, string menuHeaderText, string menuHeaderIcon)
        {
            var menuHeader = _menuHeaderService.GetSingle(c => c.MenuHeaderId == menuHeaderId).Data;
            if (menuHeader == null || String.IsNullOrEmpty(menuHeaderText)) return false;
            menuHeader.MenuHeaderText = menuHeaderText;
            menuHeader.MenuHeaderIconPath = menuHeaderIcon;
            _menuHeaderService.Update(menuHeader);
            return true;
        }
        public MenuHeader GetMenuHeader(int menuHeaderId) => _menuHeaderService.GetSingle(c => c.MenuHeaderId == menuHeaderId).Data;
        public Module GetModule(int moduleId) => _moduleService.GetSingle(c => c.ModuleId == moduleId).Data;
        public List<Module> GetModuleList() => _moduleService.GetAll(c => !c.Passive).Data;
        public List<Menu> GetMenuList() => _menuService.GetAll(c => !c.Passive).Data;
        public List<MenuHeader> GetMenuHeaderList() => _menuHeaderService.GetAll(c => !c.Passive).Data;
    }
}