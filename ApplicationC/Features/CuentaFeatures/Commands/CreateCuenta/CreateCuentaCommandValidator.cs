using ApplicationC.Features.CuentaFeatures.Validators;
using ApplicationC.Interfaces.Repositories;
using FluentValidation;

namespace ApplicationC.Features.CuentaFeatures.Commands.CreateCuenta
{
    public class CreateCuentaCommandValidator : AbstractValidator<CreateCuentaCommand>
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CreateCuentaCommandValidator(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
            RuleFor(p => p.SaldoInicial).SaldoInicialValidator();
            RuleFor(p => p.TipoCuenta).TipoCuentaValidator();
            RuleFor(p => p.NumeroCuenta).NumeroCuentaUnica(_cuentaRepository);
        }
    }
}
