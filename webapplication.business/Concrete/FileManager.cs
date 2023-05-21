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
        private readonly IModuleService _moduleService;
        private readonly IMenuHeaderService _menuHeaderService;
        public FileManager(IFileHelper fileHelper, IModuleService moduleService, IMenuHeaderService menuHeaderService)
        {
            _fileHelper = fileHelper;
            _moduleService = moduleService;
            _menuHeaderService = menuHeaderService;
        }
        // public IResult AddForModule(IFormFile file, Module module)
        // {
        //     var folderName = "\\app\\media\\MenuIcons\\";
        //     if (!string.IsNullOrEmpty(module.ModuleIconPath))
        //     {
        //         _fileHelper.Remove(module.ModuleIconPath, folderName);
        //     }
        //     var imageResult = _fileHelper.Upload(file, folderName);
        //     if (!imageResult.Success)
        //     {
        //         return new ErrorResult("Resim Yüklenemedi.");
        //     }
        //     module.ModuleIconPath = imageResult.Message;
        //     _moduleService.Update(module);
        //     return new SuccessResult("Resim yükleme başarılı!");
        // }
        // public IResult AddForMenuHeader(IFormFile file, MenuHeader menuHeader)
        // {
        //     var folderName = "\\app\\media\\MenuIcons\\";
        //     if (!string.IsNullOrEmpty(menuHeader.MenuHeaderIconPath))
        //     {
        //         _fileHelper.Remove(menuHeader.MenuHeaderIconPath, folderName);
        //     }
        //     var imageResult = _fileHelper.Upload(file, folderName);
        //     if (!imageResult.Success)
        //     {
        //         return new ErrorResult("Resim Yüklenemedi.");
        //     }
        //     menuHeader.MenuHeaderIconPath = imageResult.Message;
        //     _menuHeaderService.Update(menuHeader);
        //     return new SuccessResult("Resim yükleme başarılı!");
        // }
    }
}