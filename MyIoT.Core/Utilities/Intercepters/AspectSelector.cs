//System
using System.Reflection;
using Castle.DynamicProxy;

namespace MyIoT.Core.Utilities.Intercepters;

public class AspectSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var managers = type.GetCustomAttributes<MethodAspectBase>(true).ToList();
        var paramsEntity = type.GetMethod(method.Name).GetCustomAttributes<MethodAspectBase>(true);
        managers.AddRange(paramsEntity);

        return managers.OrderBy(o => o.Priority).ToArray();
    }
}
