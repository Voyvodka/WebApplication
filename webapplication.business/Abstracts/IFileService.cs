using Microsoft.AspNetCore.Http;
using webapplication.core.Utilities.Results;
using webapplication.entity.Menu;
namespace webapplication.business.Abstracts
{
    public interface IFileService
    {
        IResult AddForModule(IFormFile file, Module module);
        IResult AddForMenuHeader(IFormFile file, MenuHeader menuHeader);
    }
}