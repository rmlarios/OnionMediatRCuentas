using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Exceptions;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using MediatR;

namespace ApplicationC.Features.ClienteFeatures.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<Response<int>>
    {
        [Required]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Identificacion { get; set; }
        [Required]
        public string Dirección { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Contraseña { get; set; }
        public bool Estado { get; set; }

        public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
        {
            private readonly IClienteRepository _clienteRepository;

            public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
            {
                _clienteRepository = clienteRepository;
            }
            public async Task<Response<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
            {
                var cliente = await _clienteRepository.GetByIdAsync(request.Id);

                if (cliente is null)
                {
                    throw new ApiException($"Cliente no encontrado.");
                }
                else
                {
                    cliente.Nombre = request.Nombre;
                    cliente.Edad = request.Edad;
                    cliente.Genero = request.Genero;
                    cliente.Dirección = request.Dirección;
                    cliente.Identificacion = request.Identificacion;
                    cliente.Telefono = request.Telefono;
                    cliente.Contraseña = request.Contraseña;
                    cliente.Estado = request.Estado;
                    await _clienteRepository.UpdateAsync(cliente);
                    return new Response<int>(cliente.Id);
                }
            }
        }
    }
}
