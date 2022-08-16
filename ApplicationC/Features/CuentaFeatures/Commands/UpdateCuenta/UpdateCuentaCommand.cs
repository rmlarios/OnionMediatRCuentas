using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Exceptions;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using Domain;
using FluentValidation.Results;
using MediatR;
using ValidationException = ApplicationC.Exceptions.ValidationException;

namespace ApplicationC.Features.CuentaFeatures.Commands.UpdateCuenta
{
    public class UpdateCuentaCommand : IRequest<Response<int>>
    {
        [Required]
        public int Id { get; set; }
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

        public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand, Response<int>>
        {
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IClienteRepository _clienteRepository;

            public UpdateCuentaCommandHandler(ICuentaRepository cuentaRepository, IClienteRepository clienteRepository)
            {
                _cuentaRepository = cuentaRepository;
                _clienteRepository = clienteRepository;
            }
            public async Task<Response<int>> Handle(UpdateCuentaCommand request, CancellationToken cancellationToken)
            {
                var cuenta = await _cuentaRepository.GetByIdAsync(request.Id);
                if (cuenta is null)
                    throw new KeyNotFoundException($"{nameof(Cuenta)} no encontrada.");
                

                var cliente = await _clienteRepository.GetByIdAsync(request.ClienteId);
                if (cliente is null)
                {
                    throw new KeyNotFoundException($"{nameof(Cliente)} no encontrado.");
                }

                if (!await _cuentaRepository.EsNumeroCuentaUnicoAsync(request.NumeroCuenta, request.Id))
                {
                    throw new ValidationException(new List<ValidationFailure>
                    {
                        new ValidationFailure("NumeroCuenta","Número de Cuenta ya está en uso")
                    });
                }

                cuenta.NumeroCuenta = request.NumeroCuenta;
                cuenta.TipoCuenta = request.TipoCuenta;
                cuenta.SaldoInicial = request.SaldoInicial;
                cuenta.Estado = request.Estado;
                cuenta.Cliente = cliente;
                await _cuentaRepository.UpdateAsync(cuenta);

                return new Response<int>(cuenta.Id);
            }
        }
    }
}
