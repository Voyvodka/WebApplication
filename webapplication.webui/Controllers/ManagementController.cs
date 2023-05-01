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
        public bool SaveModule(Module module, IFormFile file)
        {
            if (String.IsNullOrEmpty(module.ModuleText)) return false;
            _moduleService.Add(module);
            if (file != null) _fileService.AddForModule(file, module);
            return true;
        }
        public bool SaveMenuHeader(MenuHeader menuHeader, IFormFile file)
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
        public bool SaveMenu(Menu menu, IFormFile file)
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
            //if (file != null) _fileService.AddForMenuHeader(file, menu);
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
        // public bool ClearModuleMenuTable()
        // {
        //     _moduleMenuService.GetAll().Data.ForEach(item => _moduleMenuService.Delete(item));
        //     return true;
        // }
        public bool ModuleByMenu(int moduleId, string menuIds)
        {
            if (String.IsNullOrEmpty(menuIds) || menuIds == "[]") return false;
            foreach (var id in JsonConvert.DeserializeObject<int[]>(menuIds))
            {
                _moduleMenuService.Add(new ModuleMenu
                {
                    MenuId = id,
                    ModuleId = moduleId,
                });
            }
            return true;
        }
    }
}