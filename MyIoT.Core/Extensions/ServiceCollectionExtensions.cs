//System
using System;
using Microsoft.Extensions.DependencyInjection;

//Projects
using MyIoT.Core.Utilities.IoC;

namespace MyIoT.Core.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
		{
			foreach (var module in modules)
			{
				module.Load(services);
			}

			return ServiceHelper.Create(services);
		}
	}
}

