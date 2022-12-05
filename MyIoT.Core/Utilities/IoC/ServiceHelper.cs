//System
using System;
using Microsoft.Extensions.DependencyInjection;

namespace MyIoT.Core.Utilities.IoC;

public static class ServiceHelper
{
	public static IServiceProvider ServiceProvider { get; set; }

	public static IServiceCollection Create(IServiceCollection services)
	{
		ServiceProvider = services.BuildServiceProvider();
		return (IServiceCollection)services;
	}
}

