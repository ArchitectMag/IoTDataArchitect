//System
using System;
using System.Diagnostics;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

//Projects
using MyIoT.Core.Utilities.Intercepters;
using MyIoT.Core.Utilities.IoC;

namespace MyIoT.Core.Aspects.Autofac.Performance;

public class PerformanceAspect : MethodAspect
{
    private int _interval;
    private Stopwatch _stopwatch;

    public PerformanceAspect(int interval)
    {
        _interval = interval;
        _stopwatch = ServiceHelper.ServiceProvider.GetService<Stopwatch>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _stopwatch.Start();
    }

    protected override void OnAfter(IInvocation invocation)
    {
        if (_stopwatch.Elapsed.TotalSeconds > _interval)
        {
            Debug.WriteLine($"Performance {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} <-Timer-> {_stopwatch.Elapsed.TotalSeconds}");
        }
        _stopwatch.Stop();
    }
}

