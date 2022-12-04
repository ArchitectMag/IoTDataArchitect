//System
using FluentValidation;

//Projects
using MyIoT.Entities.Models;

namespace MyIoT.Business.VaidationRules.FluentValidation;

public class LightValidation : AbstractValidator<Light>
{
    public LightValidation()
    {
        RuleFor(v => v.LightSensorValue).NotEmpty();

    }
}
