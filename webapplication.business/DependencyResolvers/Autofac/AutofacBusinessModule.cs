using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapplication.business.Abstracts;
using webapplication.business.Concrete;
using webapplication.core.Utilities.Helpers;
using webapplication.core.Utilities.Interceptors;
using webapplication.dataaccess.Abstracts;
using webapplication.dataaccess.Concretes;
using webapplication.dataaccess.Contexts;
namespace webapplication.business.DependencyResolvers.Autofac
{
    public class AutofacBusinessmodule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CountryDal>().As<ICountryDal>().SingleInstance();
            builder.RegisterType<CountryManager>().As<ICountryService>().SingleInstance();
            builder.RegisterType<CityDal>().As<ICityDal>().SingleInstance();
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<StateDal>().As<IStateDal>().SingleInstance();
            builder.RegisterType<StateManager>().As<IStateService>().SingleInstance();
            builder.RegisterType<MenuDal>().As<IMenuDal>().SingleInstance();
            builder.RegisterType<MenuManager>().As<IMenuService>().SingleInstance();
            builder.RegisterType<MenuHeaderDal>().As<IMenuHeaderDal>().SingleInstance();
            builder.RegisterType<MenuHeaderManager>().As<IMenuHeaderService>().SingleInstance();
            builder.RegisterType<MenuModuleDal>().As<IMenuModuleDal>().SingleInstance();
            builder.RegisterType<MenuModuleManager>().As<IMenuModuleService>().SingleInstance();
            builder.RegisterType<ModuleMenuDal>().As<IModuleMenuDal>().SingleInstance();
            builder.RegisterType<ModuleMenuManager>().As<IModuleMenuService>().SingleInstance();
            builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();
            builder.RegisterType<ApplicationDbContext>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<IdentityErrorDescriber>().As<IdentityErrorDescriber>().InstancePerLifetimeScope();
            builder.RegisterType<RoleStore<IdentityRole>>()
            .As<IRoleStore<IdentityRole>>()
            .InstancePerLifetimeScope();
            builder.RegisterType<RoleManager<IdentityRole>>()
            .As<RoleManager<IdentityRole>>()
            .InstancePerLifetimeScope();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}