using System.Linq;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Parametrics;
using FluentValidation;

namespace ApplicationC.Features.CuentaFeatures.Validators
{
    public static class CuentaCustomValidators
    {
        public static IRuleBuilderOptions<T, string> NumeroCuentaUnica<T>(this IRuleBuilder<T, string> rule, ICuentaRepository cuentaRepository) where T : class
        {
            return rule.MustAsync<T, string>((arg1, s, arg3) =>
            {
                return cuentaRepository.EsNumeroCuentaUnicoAsync(s);
            }).WithMessage("EL Número de Cuenta ya existe");
        }
    }
}
