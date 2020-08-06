using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Intercepters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple = true,Inherited = true)]
    public abstract class MethodAspectBase : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
