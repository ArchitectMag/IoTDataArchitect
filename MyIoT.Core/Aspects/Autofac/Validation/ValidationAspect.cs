//System
using System;
using System.Linq;
using FluentValidation;
using Castle.DynamicProxy;
using System.Threading.Tasks;

//Projects
using MyIoT.Core.Utilities.Intercepters;
using MyIoT.Core.CrossCuttingConcerns.Validations;

namespace MyIoT.Core.Aspects.Autofac.Validation;

public class ValidationAspect : MethodAspect
{
    private Type _validationType;
    public ValidationAspect(Type validatorType)
    {
        if (!typeof(IValidator).IsAssignableFrom(validatorType))
        {
            throw new Exception("hatalı validation türü");
        }
        _validationType = validatorType;
    }

    protected async Task OnBefore(IInvocation invocation)
    {
        var validator = (IValidator)Activator.CreateInstance(_validationType);
        var entityType = _validationType.BaseType.GetGenericArguments()[0];
        var entities = invocation.Arguments.Where(a => a.GetType() == entityType);
        foreach (var entity in entities)
        {
            await ValidationManager.Validation(validator, entity);
        }
    }
}