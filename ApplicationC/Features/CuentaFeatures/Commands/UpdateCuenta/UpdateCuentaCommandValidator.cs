using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Features.CuentaFeatures.Validators;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Parametrics;
using ApplicationC.Validators;
using FluentValidation;
using FluentValidation.Internal;

namespace ApplicationC.Features.CuentaFeatures.Commands.UpdateCuenta
{
    public class UpdateCuentaCommandValidator : AbstractValidator<UpdateCuentaCommand>
    {
        private readonly ICuentaRepository _cuentaRepository;
        public UpdateCuentaCommandValidator(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
            RuleFor(p => p.SaldoInicial).PermitirSoloPositivos();
            RuleFor(p => p.TipoCuenta).PermitirSoloValoresEspecificos(TipoCuenta.TiposCuenta);
        }

        private async Task<bool> IsUniqueBarcode(UpdateCuentaCommand cuenta, string numeroCuenta, CancellationToken cancellationToken)
        {
            return await _cuentaRepository.EsNumeroCuentaUnicoAsync(numeroCuenta, cuenta.Id);
        }
    }
}
