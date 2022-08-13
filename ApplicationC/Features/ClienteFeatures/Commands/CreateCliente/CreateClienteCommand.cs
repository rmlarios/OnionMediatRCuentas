using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using AutoMapper;
using Domain;
using MediatR;

namespace ApplicationC.Features.ClienteFeatures.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<Response<int>>
    {
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
    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<int>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public CreateClienteCommandHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Cliente>(request);
            await _clienteRepository.AddAsync(cliente);
            return new Response<int>(cliente.Id);
        }
    }
}
