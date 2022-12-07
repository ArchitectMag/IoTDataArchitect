//System
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

//Project
using MyIoT.Core.Utilities.IoC;
using MyIoT.Core.Utilities.Intercepters;
using MyIoT.Core.CrossCuttingConcerns.Caching;

namespace MyIoT.Core.Aspects.Autofac.Caching;

public class CacheClearAspect : MethodAspect
{
    private string _pattern;
    private ICacheManager _cacheManager;

    public CacheClearAspect(string pattern)
    {
        _pattern = pattern;
        _cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheManager>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        _cacheManager.RemoveByPattern(_pattern);
    }
}