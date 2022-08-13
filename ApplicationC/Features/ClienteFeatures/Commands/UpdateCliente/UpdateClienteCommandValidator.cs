using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Features.ClienteFeatures.Commands.UpdateCliente;
using ApplicationC.Features.ClienteFeatures.Validators;
using ApplicationC.Interfaces.Repositories;
using FluentValidation;

namespace ApplicationC.Features.ClienteFeatures.Commands.CreateCliente
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public UpdateClienteCommandValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

            RuleFor(p => p.Nombre).NombreValidator();
            RuleFor(p => p.Edad).EdadValidator();

        }
    }
}
