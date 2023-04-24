using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using webapplication.business.Abstracts;
using webapplication.business.Concrete;
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
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}