using Microsoft.AspNetCore.Http;
using webapplication.core.Utilities.Results;
namespace webapplication.core.Utilities.Helpers
{
    public interface IFileHelper
    {
        void RemoveOldFile(string directory);
        void CreateFile(string directory, IFormFile file);
        void CheckDirectoryExist(string directory);
        IResult CheckFileTypeValid(string type);
        IResult CheckFileExist(IFormFile file);
        IResult Upload(IFormFile file, string folderName);
        IResult Update(IFormFile file, string imagePath);
        IResult Remove(string path, string folderName);
    }
}
