using Business.Interfaces;
using Business.Managers;
using Core.Utilities.Localization;
using Core.Utilities.Messages;
using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace IOT.Business.IOCInversion
{
    public class ScopeManager
    {
        private IServiceCollection _services;

        public ScopeManager(IServiceCollection services)
        {
            _services = services;

            _services.AddScoped<IMessage, MessageManager>();

            _services.AddScoped<ILightService, LightManager>();
            _services.AddScoped<ILightDal, LightDal>();
        }
    }
}