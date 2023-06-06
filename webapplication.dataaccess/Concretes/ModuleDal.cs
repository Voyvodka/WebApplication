using webapplication.core.DataAccess.EntityFramework;
using webapplication.dataaccess.Abstracts;
using webapplication.dataaccess.Contexts;
using webapplication.entity;
namespace webapplication.dataaccess.Concretes
{
    public class ModuleDal : EfEntityRepositoryBase<Module, ApplicationDbContext>, IModuleDal
    {
    }
}