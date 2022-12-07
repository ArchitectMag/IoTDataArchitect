//System
using System.Transactions;
using Castle.DynamicProxy;

//Projects
using MyIoT.Core.Utilities.Intercepters;

namespace MyIoT.Core.Aspects.Autofac.Transaction;

public class TransactionAspect : MethodAspect
{
    public override void Intercept(IInvocation invocation)
    {
        using (TransactionScope transactionScope = new TransactionScope())
        {
            try
            {
                invocation.Proceed();
                transactionScope.Complete();
            }
            catch (Exception ex)
            {
                transactionScope.Dispose();
                throw;

            }
        }
    }
}

