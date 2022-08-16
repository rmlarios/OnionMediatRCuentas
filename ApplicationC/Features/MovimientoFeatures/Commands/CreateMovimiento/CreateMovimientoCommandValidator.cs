using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Parametrics;
using ApplicationC.Validators;
using FluentValidation;

namespace ApplicationC.Features.MovimientoFeatures.Commands.CreateMovimiento
{
    public class CreateMovimientoCommandValidator : AbstractValidator<CreateMovimientoCommand>
    {
        public CreateMovimientoCommandValidator()
        {
            RuleFor(p => p.TipoMovimiento).PermitirSoloValoresEspecificos(TipoMovimiento.TiposMovimiento);
        }
    }
}
