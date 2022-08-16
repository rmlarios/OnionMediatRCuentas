using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Exceptions;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using Domain;
using MediatR;

namespace ApplicationC.Features.CuentaFeatures.Commands.DeleteCuenta
{
    public class DeleteCuentaCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteCuentaCommandHandler : IRequestHandler<DeleteCuentaCommand, Response<int>>
        {
            private readonly ICuentaRepository _cuentaRepository;
            public DeleteCuentaCommandHandler(ICuentaRepository cuentaRepository)
            {
                _cuentaRepository = cuentaRepository;
            }
            public async Task<Response<int>> Handle(DeleteCuentaCommand request, CancellationToken cancellationToken)
            {
                var cuenta = await _cuentaRepository.GetByIdAsync(request.Id);

                if (cuenta == null)
                    throw new KeyNotFoundException($"{nameof(Cuenta)} No Encontrado.");

                await _cuentaRepository.DeleteAsync(cuenta);
                return new Response<int>(cuenta.Id);
            }
        }
    }
}
