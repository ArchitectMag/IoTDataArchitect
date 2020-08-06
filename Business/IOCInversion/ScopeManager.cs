using DataAccess.Data;
using Business.Managers;
using Business.Interfaces;
using DataAccess.Interfaces;
using Core.Utilities.Messages;
using Core.Utilities.Localization;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Security.JWT;
using System.Reflection;

namespace IOT.Business.IOCInversion
{
    public class ScopeManager
    {
        private readonly IServiceCollection _services;

        public ScopeManager(IServiceCollection services)
        {
            _services = services;

            _services.AddScoped<IMessage, MessageManager>();

            _services.AddScoped<ILightService, LightManager>();
            _services.AddScoped<ILightDal, LightDal>();

            _services.AddScoped<IUserService, UserManager>();
            _services.AddScoped<IUserDal, UserDal>();

            _services.AddScoped<ITokenHelper, JWTHelper>();
            _services.AddScoped<IAuthService, AuthManager>();
        }   
    }
}