using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using Domain;
using MediatR;

namespace ApplicationC.Features.MovimientoFeatures.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteMovimientoCommandHandler : IRequestHandler<DeleteMovimientoCommand, Response<int>>
        {
            private readonly IMovimientoRepository _movimientoRepository;

            public DeleteMovimientoCommandHandler(IMovimientoRepository movimientoRepository)
            {
                _movimientoRepository = movimientoRepository;
            }
            public async Task<Response<int>> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
            {
                var movimiento = await _movimientoRepository.GetByIdAsync(request.Id);

                if (movimiento == null)
                    throw new KeyNotFoundException($"{nameof(Movimiento)} No Encontrado.");

                await _movimientoRepository.DeleteAsync(movimiento);
                return new Response<int>(movimiento.Id);
            }
        }
    }
}
