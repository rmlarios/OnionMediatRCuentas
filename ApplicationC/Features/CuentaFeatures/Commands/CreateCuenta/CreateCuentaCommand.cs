using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Exceptions;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using AutoMapper;
using Domain;
using MediatR;

namespace ApplicationC.Features.CuentaFeatures.Commands.CreateCuenta
{
    public class CreateCuentaCommand : IRequest<Response<int>>
    {
        [Required]
        public string NumeroCuenta { get; set; }
        [Required]
        public string TipoCuenta { get; set; }
        [Required]
        public double SaldoInicial { get; set; }
        [Required]
        public bool Estado { get; set; }
        [Required]
        public int ClienteId { get; set; }

        public class CreateCuentaCommandHandler : IRequestHandler<CreateCuentaCommand, Response<int>>
        {
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IClienteRepository _clienteRepository;
            private readonly IMapper _mapper;
            public CreateCuentaCommandHandler(ICuentaRepository cuentaRepository, IMapper mapper, IClienteRepository clienteRepository)
            {
                _cuentaRepository = cuentaRepository;
                _clienteRepository = clienteRepository;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateCuentaCommand request, CancellationToken cancellationToken)
            {
                var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId);

                if (cliente == null)
                    throw new ApiException($"Cliente No Econtrado.");

                var cuenta = _mapper.Map<Cuenta>(request);
                cuenta.Cliente = cliente;

                await _cuentaRepository.AddAsync(cuenta);
                return new Response<int>(cuenta.Id);
            }
        }
    }
}
