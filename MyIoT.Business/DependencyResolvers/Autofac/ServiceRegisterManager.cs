//System
using Autofac;
using Castle.DynamicProxy;

//Projects
using MyIoT.Business.Managers;
using MyIoT.Business.Interfaces;
using MyIoT.DataAccess.Concrete;
using MyIoT.DataAccess.Interfaces;
using MyIoT.Core.Utilities.Localization;
using MyIoT.Core.Utilities.Security.JWT;
using MyIoT.Core.Utilities.Intercepters;
using Autofac.Extras.DynamicProxy;

namespace MyIoT.Business.DependencyResolvers.Autofac;

public class ServiceRegisterManager : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<JWTHelper>().As<ITokenHelper>();
        builder.RegisterType<LocalizationHelper>().As<ILocalizationHelper>();
        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<LightManager>().As<ILightService>();
        builder.RegisterType<LightDal>().As<ILightDal>();
        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<UserDal>().As<IUserDal>();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
        {
            Selector = new AspectSelector()
        }).SingleInstance();
        //base.Load(builder);
    }
}