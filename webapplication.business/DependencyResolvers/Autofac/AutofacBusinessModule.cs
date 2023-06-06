using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using webapplication.business.Abstracts;
using webapplication.business.Concrete;
using webapplication.core.Utilities.Helpers;
using webapplication.core.Utilities.Interceptors;
using webapplication.dataaccess.Abstracts;
using webapplication.dataaccess.Concretes;
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
            builder.RegisterType<ModuleDal>().As<IModuleDal>().SingleInstance();
            builder.RegisterType<ModuleManager>().As<IModuleService>().SingleInstance();
            builder.RegisterType<ModuleMenuDal>().As<IModuleMenuDal>().SingleInstance();
            builder.RegisterType<ModuleMenuManager>().As<IModuleMenuService>().SingleInstance();
            builder.RegisterType<AdminMenuDal>().As<IAdminMenuDal>().SingleInstance();
            builder.RegisterType<AdminMenuManager>().As<IAdminMenuService>().SingleInstance();
            builder.RegisterType<AdminMenuHeaderDal>().As<IAdminMenuHeaderDal>().SingleInstance();
            builder.RegisterType<AdminMenuHeaderManager>().As<IAdminMenuHeaderService>().SingleInstance();
            builder.RegisterType<AdminModuleDal>().As<IAdminModuleDal>().SingleInstance();
            builder.RegisterType<AdminModuleManager>().As<IAdminModuleService>().SingleInstance();
            builder.RegisterType<AdminModuleMenuDal>().As<IAdminModuleMenuDal>().SingleInstance();
            builder.RegisterType<AdminModuleMenuManager>().As<IAdminModuleMenuService>().SingleInstance();
            builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}