//System
using Castle.DynamicProxy;

//Projects
using MyIoT.Core.Utilities.Intercepters;
using MyIoT.Core.CrossCuttingConcerns.Logging;
using MyIoT.Core.CrossCuttingConcerns.Logging.Log4Net;

namespace MyIoT.Core.Aspects.Autofac.Logger;

public class LogAspect : MethodAspect
{
    private LoggerServiceBase _loggerServiceBase;

    public LogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
        {
            throw new Exception("Wrong logger type");
        }
        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
    }

    protected override void OnBefore(IInvocation invocation)
    {
        _loggerServiceBase.Info(GetLogDetail(invocation));
    }

    private LogDetail GetLogDetail(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();
        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });
        }        

        var logDetail = new LogDetail
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters
        };

        return logDetail;
    }
}

