using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Parametrics;
using ApplicationC.Validators;
using FluentValidation;

namespace ApplicationC.Features.MovimientoFeatures.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommandValidator : AbstractValidator<UpdateMovimientoCommand>
    {
        public UpdateMovimientoCommandValidator()
        {
            RuleFor(p => p.TipoMovimiento).PermitirSoloValoresEspecificos(TipoMovimiento.TiposMovimiento);
        }
    }
}
