using Entities.Models;
using FluentValidation;

namespace Business.VaidationRules.FluentValidation
{
    public class LightValidation : AbstractValidator<Light>
    {
        public LightValidation()
        {
            RuleFor(v => v.LightSensorValue).NotEmpty();

        }
    }
}
