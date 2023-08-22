using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapplication.business.Abstracts;
using webapplication.entity.Identity;
using webapplication.entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace webapplication.webui.Controllers
{
    [Authorize]
    public class ManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IRoleGroupService _roleGroupService;
        private readonly IMenuService _menuService;
        private readonly IMenuHeaderService _menuHeaderService;
        private readonly IModuleService _moduleService;
        private readonly IModuleMenuService _moduleMenuService;
        private readonly IAdminMenuService _adminMenuService;
        private readonly IAdminMenuHeaderService _adminMenuHeaderService;
        private readonly IAdminModuleService _adminModuleService;
        private readonly IAdminModuleMenuService _adminModuleMenuService;
        private readonly IFileService _fileService;
        public ManagementController(RoleManager<ApplicationRole> roleManager, IRoleGroupService roleGroupService, IFileService fileService, IMenuService menuService, IMenuHeaderService menuHeaderService, IModuleService moduleService, IModuleMenuService moduleMenuService, IAdminMenuService adminMenuService, IAdminMenuHeaderService adminMenuHeaderService, IAdminModuleService adminModuleService, IAdminModuleMenuService adminModuleMenuService, UserManager<ApplicationUser> userManager)
        {
            _roleGroupService = roleGroupService;
            _fileService = fileService;
            _menuService = menuService;
            _menuHeaderService = menuHeaderService;
            _moduleService = moduleService;
            _moduleMenuService = moduleMenuService;
            _adminMenuService = adminMenuService;
            _adminMenuHeaderService = adminMenuHeaderService;
            _adminModuleService = adminModuleService;
            _adminModuleMenuService = adminModuleMenuService;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Ana Sayfa";
            return View();
        }
        public IActionResult MenuManagement()
        {
            ViewData["Title"] = "Menu Tanımlamaları";
            return View();
        }
        [HttpPost]
        public bool SaveModule(Module module)
        {
            if (String.IsNullOrEmpty(module.ModuleText)) return false;
            if (String.IsNullOrEmpty(module.ModuleIconPath)) module.ModuleIconPath = "";
            _moduleService.Add(module);
            return true;
        }
        [HttpPost]
        public bool SaveMenuHeader(MenuHeader menuHeader)
        {
            if (String.IsNullOrEmpty(menuHeader.MenuHeaderText)) return false;
            if (String.IsNullOrEmpty(menuHeader.MenuHeaderIconPath)) menuHeader.MenuHeaderIconPath = "";
            _menuHeaderService.Add(menuHeader);
            return true;
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
            if (menu.MenuIconPath == null) menu.MenuIconPath = "";
            _menuService.Add(menu);
            return true;
        }
        public object GetModuleMenus()
        {
            var data = new
            {
                moduleMenus = _moduleMenuService.GetList(),
                modules = _moduleService.GetList(),
            };
            data.moduleMenus.ForEach(item =>
            {
                item.Menu = _menuService.Get(c => c.MenuId == item.MenuId);
                item.Menu.MenuHeader = _menuHeaderService.Get(c => c.MenuHeaderId == item.Menu.MenuHeaderId);
            });
            return data;
        }
        [HttpPost]
        public bool AddMenuToModule(int moduleId, int menuId)
        {
            var module = _moduleService.Get(c => c.ModuleId == moduleId);
            var menu = _menuService.Get(c => c.MenuId == menuId);
            if (menu == null || module == null || _moduleMenuService.GetList(c => c.ModuleId == moduleId && c.MenuId == menuId).Any()) return false;
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
            var module = _moduleService.Get(c => c.ModuleId == moduleId);
            var menu = _menuService.Get(c => c.MenuId == menuId);
            var moduleMenu = _moduleMenuService.Get(c => c.ModuleMenuId == moduleMenuId);
            if (module == null || menu == null || moduleMenu == null) return false;
            if (moduleMenu.ModuleId != module.ModuleId && moduleMenu.MenuId != menu.MenuId) return false;
            _moduleMenuService.Delete(moduleMenu);
            return true;
        }
        public bool UpdateModule(int moduleId, string moduleText, string moduleIcon)
        {
            var module = _moduleService.Get(c => c.ModuleId == moduleId);
            if (moduleIcon == null) moduleIcon = "";
            if (module == null || String.IsNullOrEmpty(moduleText)) return false;
            module.ModuleText = moduleText;
            module.ModuleIconPath = moduleIcon;
            _moduleService.Update(module);
            return true;
        }
        public bool UpdateMenuHeader(int menuHeaderId, string menuHeaderText, string menuHeaderIcon)
        {
            var menuHeader = _menuHeaderService.Get(c => c.MenuHeaderId == menuHeaderId);
            if (menuHeader == null || String.IsNullOrEmpty(menuHeaderText)) return false;
            menuHeader.MenuHeaderText = menuHeaderText;
            if (menuHeaderIcon == null) menuHeaderIcon = "";
            menuHeader.MenuHeaderIconPath = menuHeaderIcon;
            _menuHeaderService.Update(menuHeader);
            return true;
        }
        [HttpPost]
        public bool UpdateMenu(Menu menu)
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
            if (menu.MenuIconPath == null) menu.MenuIconPath = "";
            if (String.IsNullOrEmpty(menu.MenuText)) return false;
            _menuService.Update(menu);
            return true;
        }
        public MenuHeader GetMenuHeader(int menuHeaderId) => _menuHeaderService.Get(c => c.MenuHeaderId == menuHeaderId);
        public Module GetModule(int moduleId) => _moduleService.Get(c => c.ModuleId == moduleId);
        public Menu GetMenu(int menuId) => _menuService.Get(c => c.MenuId == menuId);
        public List<Module> GetModuleList() => _moduleService.GetList(c => !c.Passive);
        public List<Menu> GetMenuList() => _menuService.GetList(c => !c.Passive);
        public List<MenuHeader> GetMenuHeaderList() => _menuHeaderService.GetList(c => !c.Passive);
        public async Task<List<ApplicationRole>> GetRoles() => await _roleManager.Roles.ToListAsync();
        public IActionResult AdminMenuManagement()
        {
            ViewData["Title"] = "Admin Menu Tanımlamaları";
            return View();
        }
        [HttpPost]
        public bool SaveAdminModule(AdminModule adminModule)
        {
            if (String.IsNullOrEmpty(adminModule.AdminModuleText)) return false;
            if (String.IsNullOrEmpty(adminModule.AdminModuleIconPath)) adminModule.AdminModuleIconPath = "";
            _adminModuleService.Add(adminModule);
            return true;
        }
        [HttpPost]
        public bool SaveAdminMenuHeader(AdminMenuHeader adminMenuHeader)
        {
            if (String.IsNullOrEmpty(adminMenuHeader.AdminMenuHeaderText)) return false;
            if (String.IsNullOrEmpty(adminMenuHeader.AdminMenuHeaderIconPath)) adminMenuHeader.AdminMenuHeaderIconPath = "";
            _adminMenuHeaderService.Add(adminMenuHeader);
            return true;
        }
        [HttpPost]
        public bool SaveAdminMenu(AdminMenu adminMenu)
        {
            var keywords = JsonConvert.DeserializeObject<dynamic[]>(adminMenu.AdminMenuKeyword);
            adminMenu.AdminMenuKeyword = "";
            if (keywords != null)
            {
                for (var i = 0; i < keywords.Length; i++)
                {
                    adminMenu.AdminMenuKeyword += keywords[i].value + "~";
                }
            }
            if (String.IsNullOrEmpty(adminMenu.AdminMenuText)) return false;
            if (adminMenu.AdminMenuIconPath == null) adminMenu.AdminMenuIconPath = "";
            _adminMenuService.Add(adminMenu);
            return true;
        }
        public object GetAdminModuleMenus()
        {
            var data = new
            {
                moduleMenus = _adminModuleMenuService.GetList(),
                modules = _adminModuleService.GetList(),
            };
            data.moduleMenus.ForEach(item =>
            {
                item.AdminMenu = _adminMenuService.Get(c => c.AdminMenuId == item.AdminMenuId);
                item.AdminMenu.AdminMenuHeader = _adminMenuHeaderService.Get(c => c.AdminMenuHeaderId == item.AdminMenu.AdminMenuHeaderId);
            });
            return data;
        }
        [HttpPost]
        public bool AdminAddMenuToModule(int moduleId, int menuId)
        {
            var module = _adminModuleService.Get(c => c.AdminModuleId == moduleId);
            var menu = _adminMenuService.Get(c => c.AdminMenuId == menuId);
            if (menu == null || module == null || _adminModuleMenuService.GetList(c => c.AdminModuleId == moduleId && c.AdminMenuId == menuId).Any()) return false;
            _adminModuleMenuService.Add(new AdminModuleMenu
            {
                AdminMenuId = menuId,
                AdminModuleId = moduleId
            });
            return true;
        }
        [HttpPost]
        public bool AdminRemoveModuleMenus(int moduleId, int menuId, int moduleMenuId)
        {
            var module = _adminModuleService.Get(c => c.AdminModuleId == moduleId);
            var menu = _adminMenuService.Get(c => c.AdminMenuId == menuId);
            var moduleMenu = _adminModuleMenuService.Get(c => c.AdminModuleMenuId == moduleMenuId);
            if (module == null || menu == null || moduleMenu == null) return false;
            if (moduleMenu.AdminModuleId != module.AdminModuleId && moduleMenu.AdminMenuId != menu.AdminMenuId) return false;
            _adminModuleMenuService.Delete(moduleMenu);
            return true;
        }
        public bool UpdateAdminModule(int moduleId, string moduleText, string moduleIcon)
        {
            var module = _adminModuleService.Get(c => c.AdminModuleId == moduleId);
            if (moduleIcon == null) moduleIcon = "";
            if (module == null || String.IsNullOrEmpty(moduleText)) return false;
            module.AdminModuleText = moduleText;
            module.AdminModuleIconPath = moduleIcon;
            _adminModuleService.Update(module);
            return true;
        }
        public bool UpdateAdminMenuHeader(int menuHeaderId, string menuHeaderText, string menuHeaderIcon)
        {
            var menuHeader = _adminMenuHeaderService.Get(c => c.AdminMenuHeaderId == menuHeaderId);
            if (menuHeader == null || String.IsNullOrEmpty(menuHeaderText)) return false;
            menuHeader.AdminMenuHeaderText = menuHeaderText;
            if (menuHeaderIcon == null) menuHeaderIcon = "";
            menuHeader.AdminMenuHeaderIconPath = menuHeaderIcon;
            _adminMenuHeaderService.Update(menuHeader);
            return true;
        }
        [HttpPost]
        public bool UpdateAdminMenu(AdminMenu menu)
        {
            var keywords = JsonConvert.DeserializeObject<dynamic[]>(menu.AdminMenuKeyword);
            menu.AdminMenuKeyword = "";
            if (keywords != null)
            {
                for (var i = 0; i < keywords.Length; i++)
                {
                    menu.AdminMenuKeyword += keywords[i].value + "~";
                }
            }
            if (menu.AdminMenuIconPath == null) menu.AdminMenuIconPath = "";
            if (String.IsNullOrEmpty(menu.AdminMenuText)) return false;
            _adminMenuService.Update(menu);
            return true;
        }
        public AdminMenuHeader GetAdminMenuHeader(int adminMenuHeaderId) => _adminMenuHeaderService.Get(c => c.AdminMenuHeaderId == adminMenuHeaderId);
        public AdminModule GetAdminModule(int adminModuleId) => _adminModuleService.Get(c => c.AdminModuleId == adminModuleId);
        public AdminMenu GetAdminMenu(int adminMenuId) => _adminMenuService.Get(c => c.AdminMenuId == adminMenuId);
        public List<AdminModule> GetAdminModuleList() => _adminModuleService.GetList(c => !c.Passive);
        public List<AdminMenu> GetAdminMenuList() => _adminMenuService.GetList(c => !c.Passive);
        public List<AdminMenuHeader> GetAdminMenuHeaderList() => _adminMenuHeaderService.GetList(c => !c.Passive);
        public IActionResult RoleManagement()
        {
            ViewData["Title"] = "Rol Yönetimi";
            return View();
        }
        public async Task<object> GetRolesObject(int draw, int start, int length, int sortColumn, string sortColumnDir, string searchValue, string columnName)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            columnName = char.ToUpper(columnName[0]) + columnName.Substring(1);
            var propertyInfo = typeof(ApplicationRole).GetProperty(columnName);
            var filteredData = roles.AsQueryable();
            if (!string.IsNullOrEmpty(searchValue))
            {
                filteredData = filteredData.Where(r => r.Name.ToLower().Contains(searchValue.ToLower()));
            }
            if (sortColumnDir.ToLower() == "asc")
            {
                filteredData = filteredData.OrderBy(x => propertyInfo.GetValue(x, null));
            }
            else
            {
                filteredData = filteredData.OrderByDescending(x => propertyInfo.GetValue(x, null));
            }
            filteredData = filteredData.Skip(start).Take(length);
            var filteredRecords = filteredData.Count();
            var response = new
            {
                draw = draw,
                recordsTotal = roles.Count(),
                recordsFiltered = roles.Count(),
                data = filteredData
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<bool> SaveRole(ApplicationRole role)
        {
            var existingRole = await _roleManager.FindByNameAsync(role.Name);
            if (existingRole != null)
            {
                return false;
            }
            var result = await _roleManager.CreateAsync(role);
            return result.Succeeded;
        }
        [HttpPost]
        public async Task<bool> RemoveRoleByName(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                return result.Succeeded;
            }
            return false;
        }
        [HttpPost]
        public async Task<bool> RemoveRolesByName(string[] roleNames)
        {
            foreach (var roleName in roleNames)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                    await _roleManager.DeleteAsync(role);
            }
            return true;
        }
        public async Task<bool> EditRole(ApplicationRole role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role.Id);
            if (existingRole != null)
            {
                existingRole.Name = role.Name;
                var result = await _roleManager.UpdateAsync(existingRole);
                return result.Succeeded;
            }
            return false;
        }
        public IActionResult RoleGroupManagement()
        {
            return View();
        }
        public List<RoleGroup> GetRoleGroups()
        {
            return _roleGroupService.GetList();
        }
    }
}