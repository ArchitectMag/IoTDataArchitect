//System
using System;
using Microsoft.Extensions.DependencyInjection;

namespace MyIoT.Core.Utilities.IoC;

public interface ICoreModule
{
    void Load(IServiceCollection serviceCollection);
}

