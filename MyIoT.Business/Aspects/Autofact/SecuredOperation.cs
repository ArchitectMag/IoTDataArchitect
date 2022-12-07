//System
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

//Projects
using MyIoT.Core.Extensions;
using MyIoT.Core.Utilities.IoC;
using MyIoT.Core.Utilities.Intercepters;

namespace MyIoT.Business.Aspects.Autofact;

public class SecuredOperation : MethodAspect
{
    private string[] _roles;
    private IHttpContextAccessor _httpContextAccessor;
       
    public SecuredOperation(string roles)
    {
        _roles = roles.Split(',');
        _httpContextAccessor = ServiceHelper.ServiceProvider.GetService<IHttpContextAccessor>();
    }


    protected override void OnBefore(IInvocation invocation)
    {
        var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

        foreach (var role in _roles)
        {
            if (roleClaims.Contains(role))
            {
                return;
            }
        }

        throw new Exception("Yetkiniz yok");
    }
}

