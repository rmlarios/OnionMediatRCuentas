using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Exceptions;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using MediatR;

namespace ApplicationC.Features.ClienteFeatures.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand, Response<int>>
        {
            private readonly IClienteRepository _clienteRepository;
            public DeleteClienteCommandHandler(IClienteRepository clienteRepository)
            {
                _clienteRepository = clienteRepository;
            }
            public async Task<Response<int>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
            {
                var cliente = await _clienteRepository.GetByIdAsync(request.Id);
                
                if (cliente == null) 
                    throw new ApiException($"Product Not Found.");

                await _clienteRepository.DeleteAsync(cliente);
                return new Response<int>(cliente.Id);
            }
        }
    }
}
