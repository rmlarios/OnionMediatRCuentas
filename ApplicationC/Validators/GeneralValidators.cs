using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;

namespace ApplicationC.Validators
{
    public static class GeneralValidators
    {
        public static IRuleBuilderOptions<T, double> PermitirSoloPositivos<T>(this IRuleBuilder<T, double> rule)
        {
            return rule
                .NotNull().WithMessage("{PropertyName} es Requerido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0.");
        }

        public static IRuleBuilderOptions<T, string> PermitirSoloValoresEspecificos<T>(this IRuleBuilder<T, string> rule, string[] allowedValues)
        {
            return rule
                .Must(t => allowedValues.Any(a=>a==t))// .Contains(t))
                .WithMessage("El {PropertyName} sólo admite los uno de los siguientes valores: " + string.Join(", ", allowedValues));
        }
    }
}
