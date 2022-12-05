//System
using System;
using Microsoft.Extensions.DependencyInjection;

//Projects
using MyIoT.Core.Utilities.IoC;
using MyIoT.Core.CrossCuttingConcerns.Caching;

namespace MyIoT.Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddMemoryCache();
        serviceCollection.AddSingleton<ICacheManager, MemCacheManager>();
    }
}

