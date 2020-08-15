using Autofac;
using Business.Interfaces;
using Business.Managers;
using Core.Utilities.Localization;
using Core.Utilities.Security.JWT;
using DataAccess.Data;
using DataAccess.Interfaces;

namespace Business.DependencyResolvers.Autofac
{
    public class ScopeManager : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocalizationHelper>().As<ILocalizationHelper>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<LightManager>().As<ILightService>();
            builder.RegisterType<LightDal>().As<ILightDal>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<JWTHelper>().As<ITokenHelper>();
            base.Load(builder);
        }
    }
}