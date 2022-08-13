using System.Linq;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Parametrics;
using FluentValidation;

namespace ApplicationC.Features.CuentaFeatures.Validators
{
    public static class CuentaValidators
    {
        public static IRuleBuilderOptions<T, double> SaldoInicialValidator<T>(this IRuleBuilder<T, double> rule)
        {
            return rule
                .NotNull().WithMessage("{PropertyName} es Requerido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser mayor a 0.");
        }

        public static IRuleBuilderOptions<T, string> TipoCuentaValidator<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .Must(t=> TipoCuenta.TiposCuenta.Contains(t))
                .WithMessage("El Tipo de Corriente debe ser uno de los siguientes: " + string.Join(", ", TipoCuenta.TiposCuenta));
        }

        public static IRuleBuilderOptions<T, string> NumeroCuentaUnica<T>(this IRuleBuilder<T, string> rule, ICuentaRepository cuentaRepository) where T : class
        {
            return rule.MustAsync<T, string>((arg1, s, arg3) =>
            {
                return cuentaRepository.EsNumeroCuentaUnicoAsync(s);
            }).WithMessage("EL Número de Cuenta ya existe");
        }
    }
}
