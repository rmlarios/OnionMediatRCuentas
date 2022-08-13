using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace ApplicationC.Features.ClienteFeatures.Validators
{
    public static class ClienteValidators
    {
        public static IRuleBuilderOptions<T, string> NombreValidator<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty().WithMessage("{PropertyName} es Requerido.")
                .NotNull()
                .MaximumLength(5).WithMessage("{PropertyName} no debe exceder los 50 caracteres.");
        }

        public static IRuleBuilderOptions<T, int> EdadValidator<T>(this IRuleBuilder<T, int> rule)
        {
            return rule
                .NotNull().WithMessage("{PropertyName} es Requerido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0.");
        }
    }
}
