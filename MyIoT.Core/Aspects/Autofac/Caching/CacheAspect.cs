//System
using System;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

//Projects
using MyIoT.Core.Utilities.IoC;
using MyIoT.Core.Utilities.Intercepters;
using MyIoT.Core.CrossCuttingConcerns.Caching;

namespace MyIoT.Core.Aspects.Autofac.Caching;

public class CacheAspect : MethodAspect
{
    private int _duration;
    private ICacheManager _cacheManager;

    public CacheAspect(int duration = 60)
    {
        _duration = duration;
        _cacheManager = ServiceHelper.ServiceProvider.GetService<ICacheManager>();
    }

    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(a => a?.ToString() ?? "<Null>"))})";

        if (_cacheManager.IsAdd(key))
        {
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }

        invocation.Proceed();
        _cacheManager.Add(key,invocation.ReturnValue,_duration);
    }
}

