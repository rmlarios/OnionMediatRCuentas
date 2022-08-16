using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using Domain;
using MediatR;

namespace ApplicationC.Features.MovimientoFeatures.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommand : IRequest<Response<int>>
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "La Fecha es requerida")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El Tipo de Movimiento es Requerido")]
        public string TipoMovimiento { get; set; }
        [Required(ErrorMessage = "El Valor es Requerido")]
        public double Valor { get; set; }
        [Required]
        public int CuentaId { get; set; }

        public class UpdateMovimientoCommandHandler : IRequestHandler<UpdateMovimientoCommand, Response<int>>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly ICuentaRepository _cuentaRepository;

            public UpdateMovimientoCommandHandler(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository)
            {
                _movimientoRepository = movimientoRepository;
                _cuentaRepository = cuentaRepository;
            }
            public async Task<Response<int>> Handle(UpdateMovimientoCommand request, CancellationToken cancellationToken)
            {
                var movimiento = await _movimientoRepository.GetByIdAsync(request.Id);
                if (movimiento == null)
                    throw new KeyNotFoundException($"{nameof(Movimiento)} No Encontrado");

                var cuenta = await _cuentaRepository.GetByIdAsync(request.CuentaId,new string[]{"Movimientos"});
                if(cuenta==null)
                    throw new KeyNotFoundException($"{nameof(Cuenta)} No Encontrada");

                movimiento.Fecha = request.Fecha;
                movimiento.TipoMovimiento = request.TipoMovimiento;
                movimiento.Valor = request.Valor;
                movimiento.Cuenta = cuenta;

                movimiento.Validar(movimiento.Id);

                movimiento.CalcularSaldo();
                await _movimientoRepository.UpdateAsync(movimiento);
                return new Response<int>(movimiento.Id);
            }
        }
    }
}
