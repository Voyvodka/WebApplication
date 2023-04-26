using Microsoft.AspNetCore.Http;
using webapplication.core.Utilities.Results;
using webapplication.entity.Menu;
namespace webapplication.business.Abstracts
{
    public interface IFileService
    {
        IResult AddForMenuModule(IFormFile file, MenuModule menuModule);
        IResult AddForMenuHeader(IFormFile file, MenuHeader menuHeader);
    }
}