using Microsoft.AspNetCore.Http;
using webapplication.business.Abstracts;
using webapplication.core.Utilities.Helpers;
using webapplication.core.Utilities.Results;
using webapplication.entity.Menu;
namespace webapplication.business.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IFileHelper _fileHelper;
        private readonly IMenuModuleService _menuModuleService;
        private readonly IMenuHeaderService _menuHeaderService;
        public FileManager(IFileHelper fileHelper, IMenuModuleService menuModuleService, IMenuHeaderService menuHeaderService)
        {
            _fileHelper = fileHelper;
            _menuModuleService = menuModuleService;
            _menuHeaderService = menuHeaderService;
        }
        public IResult AddForMenuModule(IFormFile file, MenuModule menuModule)
        {
            var folderName = "\\app\\media\\MenuIcons\\";
            if (!string.IsNullOrEmpty(menuModule.MenuModuleIconPath))
            {
                _fileHelper.Remove(menuModule.MenuModuleIconPath, folderName);
            }
            var imageResult = _fileHelper.Upload(file, folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }
            menuModule.MenuModuleIconPath = imageResult.Message;
            _menuModuleService.Update(menuModule);
            return new SuccessResult("Resim yükleme başarılı!");
        }
        public IResult AddForMenuHeader(IFormFile file, MenuHeader menuHeader)
        {
            var folderName = "\\app\\media\\MenuIcons\\";
            if (!string.IsNullOrEmpty(menuHeader.MenuHeaderIconPath))
            {
                _fileHelper.Remove(menuHeader.MenuHeaderIconPath, folderName);
            }
            var imageResult = _fileHelper.Upload(file, folderName);
            if (!imageResult.Success)
            {
                return new ErrorResult("Resim Yüklenemedi.");
            }
            menuHeader.MenuHeaderIconPath = imageResult.Message;
            _menuHeaderService.Update(menuHeader);
            return new SuccessResult("Resim yükleme başarılı!");
        }
    }
}