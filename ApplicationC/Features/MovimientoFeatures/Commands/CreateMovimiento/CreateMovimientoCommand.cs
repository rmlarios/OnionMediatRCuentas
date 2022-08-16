using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Exceptions;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using AutoMapper;
using Domain;
using MediatR;
using ApplicationC.Parametrics;
using ValidationException = ApplicationC.Exceptions.ValidationException;

namespace ApplicationC.Features.MovimientoFeatures.Commands.CreateMovimiento
{
    public class CreateMovimientoCommand : IRequest<Response<int>>
    {
        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El Tipo de Movimiento es Requerido")]
        public string TipoMovimiento { get; set; }
        [Required(ErrorMessage = "El Valor es Requerido")]
        public double Valor { get; set; }
        [Required]
        public int CuentaId { get; set; }

        public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand, Response<int>>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IMapper _mapper;
            public CreateMovimientoCommandHandler(IMovimientoRepository movimientoRepository, IMapper mapper, ICuentaRepository cuentaRepository)
            {
                _movimientoRepository = movimientoRepository;
                _cuentaRepository = cuentaRepository;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(CreateMovimientoCommand request, CancellationToken cancellationToken)
            {
                var cuenta = await _cuentaRepository.GetByIdAsync(request.CuentaId,new string[] {"Movimientos"});
                if (cuenta == null)
                    throw new KeyNotFoundException($"{nameof(Cuenta)} No Encontrada.");

                var movimiento = _mapper.Map<Movimiento>(request);
                movimiento.Cuenta = cuenta;

                var resultValidation = movimiento.Validar();
                if (resultValidation.HasErrors)
                    throw new ValidationException(resultValidation.Errors);
               
                movimiento.CalcularSaldo();
                await _movimientoRepository.AddAsync(movimiento);
                return new Response<int>(movimiento.Id);
            }
        }
    }
}
