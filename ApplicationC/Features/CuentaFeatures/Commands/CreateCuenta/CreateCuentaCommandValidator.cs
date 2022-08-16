using ApplicationC.Features.CuentaFeatures.Validators;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Parametrics;
using ApplicationC.Validators;
using FluentValidation;

namespace ApplicationC.Features.CuentaFeatures.Commands.CreateCuenta
{
    public class CreateCuentaCommandValidator : AbstractValidator<CreateCuentaCommand>
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CreateCuentaCommandValidator(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
            RuleFor(p => p.SaldoInicial).PermitirSoloPositivos();
            RuleFor(p => p.TipoCuenta).PermitirSoloValoresEspecificos(TipoCuenta.TiposCuenta);
            RuleFor(p => p.NumeroCuenta).NumeroCuentaUnica(_cuentaRepository);
        }
    }
}
