using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using webapplication.core.CrossCuttingConcerns.Caching;
using webapplication.core.Utilities.Interceptors;
using webapplication.core.Utilities.IoC;

namespace webapplication.core.Aspect.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
