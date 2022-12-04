//System
using Autofac;

//Projects
using MyIoT.DataAccess.Data;
using MyIoT.Business.Managers;
using MyIoT.Business.Interfaces;
using MyIoT.DataAccess.Interfaces;
using MyIoT.Core.Utilities.Localization;
using MyIoT.Core.Utilities.Security.JWT;

namespace MyIoT.Business.DependencyResolvers.Autofac;

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