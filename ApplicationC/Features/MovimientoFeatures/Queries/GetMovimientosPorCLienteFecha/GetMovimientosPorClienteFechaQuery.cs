using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Specifications;
using ApplicationC.Wrappers;
using AutoMapper;
using Domain;
using MediatR;

namespace ApplicationC.Features.MovimientoFeatures.Queries.GetMovimientosPorCLienteFecha
{
    public class GetMovimientosPorClienteFechaQuery : RequestSpecification, IRequest<PagedResponse<IEnumerable<MovimientosPorClienteFechaDto>>>
    {
        [Required]
        public int ClienteId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaInicio { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaFin { get; set; }

        public class GetMovimientosPorClienteFechaQueryHandler : IRequestHandler<GetMovimientosPorClienteFechaQuery, PagedResponse<IEnumerable<MovimientosPorClienteFechaDto>>>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly IClienteRepository _clienteRepository;
            private readonly IMapper _mapper;

            public GetMovimientosPorClienteFechaQueryHandler(IMovimientoRepository movimientoRepository, IClienteRepository clienteRepository, IMapper mapper)
            {
                _movimientoRepository = movimientoRepository;
                _clienteRepository = clienteRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<IEnumerable<MovimientosPorClienteFechaDto>>> Handle(GetMovimientosPorClienteFechaQuery request, CancellationToken cancellationToken)
            {
                var spec = _mapper.Map<GetMovimientosPorClienteFechaSpec>(request);
                var cliente =await _clienteRepository.GetByIdAsync(request.ClienteId);

                if (cliente == null)
                    throw new KeyNotFoundException($"{nameof(Cliente)} No Encontrado.");

                Expression<Func<Movimiento, bool>> filter = m => m.Cuenta.Cliente.Id == spec.ClienteId &&
                    m.Fecha.Date >= spec.FechaInicio.Date &&
                    m.Fecha.Date <= spec.FechaFin.Date;

                var movimientos = await _movimientoRepository.GetPagedReponseAsync(spec.PageNumber, spec.PageSize, "Cuenta,Cuenta.Cliente",filter);
                var movimientosPorClienteFecha = movimientos.Select(m => new MovimientosPorClienteFechaDto
                {
                    Fecha = m.Fecha,
                    Cliente = cliente.Nombre,
                    NumeroCuenta = m.Cuenta.NumeroCuenta,
                    Tipo = m.TipoMovimiento,
                    SaldoInicial = m.Cuenta.SaldoInicial,
                    Estado = m.Cuenta.Estado,
                    Movimiento = m.Valor,
                    SaldoDisponible = m.Saldo
                }).ToList();
                return new PagedResponse<IEnumerable<MovimientosPorClienteFechaDto>>(movimientosPorClienteFecha,
                    spec.PageNumber, spec.PageSize);
            }
        }
    }
}
