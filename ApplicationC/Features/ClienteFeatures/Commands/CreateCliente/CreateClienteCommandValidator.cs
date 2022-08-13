using System;
using System.Collections.Generic;
using System.Text;
using ApplicationC.Features.ClienteFeatures.Validators;
using ApplicationC.Interfaces.Repositories;
using FluentValidation;

namespace ApplicationC.Features.ClienteFeatures.Commands.CreateCliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        private readonly IClienteRepository _clienteRepository;

        public CreateClienteCommandValidator(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;

            RuleFor(p => p.Nombre).NombreValidator();
            RuleFor(p => p.Edad).EdadValidator();
        }
    }
}
