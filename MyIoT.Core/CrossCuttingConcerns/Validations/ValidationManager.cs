//System
using FluentValidation;
using System.Threading.Tasks;

namespace MyIoT.Core.CrossCuttingConcerns.Validations;

public static class ValidationManager
{
    public static async Task Validation(IValidator validator, object entity)
    {
        var result = await validator.ValidateAsync((IValidationContext)entity);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}
