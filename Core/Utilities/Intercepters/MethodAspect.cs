using Castle.DynamicProxy;

namespace Core.Utilities.Intercepters
{
    public abstract class MethodAspect : MethodAspectBase
    {
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBeforeAsync(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception)
            {
                isSuccess = false;
                OnException(invocation);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }

        protected virtual void OnBeforeAsync(IInvocation invocation)
        {
        }

        protected virtual void OnAfter(IInvocation invocation)
        {

        }

        protected virtual void OnException(IInvocation invocation)
        {

        }

        protected virtual void OnSuccess(IInvocation invocation)
        {

        }
    }
}
