using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Specifications;
using ApplicationC.Wrappers;
using AutoMapper;
using Domain;
using MediatR;

namespace ApplicationC.Features.CuentaFeatures.Queries.GetAllCuentas
{
    public class GetAllCuentasQuery : RequestSpecification, IRequest<PagedResponse<IEnumerable<CuentaDto>>>
    {
        public  bool? FilterEstado { get; set; }
        public  int? FilterIdCliente { get; set; }

        public class GetAllCuentasQueryHandler : IRequestHandler<GetAllCuentasQuery, PagedResponse<IEnumerable<CuentaDto>>>
        {
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IMapper _mapper;

            public GetAllCuentasQueryHandler(ICuentaRepository cuentaRepository, IMapper mapper)
            {
                _cuentaRepository = cuentaRepository;
                _mapper = mapper;
            }

            public async Task<PagedResponse<IEnumerable<CuentaDto>>> Handle(GetAllCuentasQuery request, CancellationToken cancellationToken)
            {
                var spec = _mapper.Map<GetAllCuentasSpecification>(request);
                var cuentas = GetQuery(await _cuentaRepository.GetPagedReponseAsync(spec.PageNumber, spec.PageSize,"Cliente,Movimientos"), request);
                var cuentasDto = _mapper.Map<IEnumerable<CuentaDto>>(cuentas);
                return new PagedResponse<IEnumerable<CuentaDto>>(cuentasDto, spec.PageNumber, spec.PageSize);
            }

            protected internal virtual List<Cuenta> GetQuery(List<Cuenta> query,
                GetAllCuentasQuery request)
            {
                if (request.FilterEstado.HasValue)
                {
                    query = query.Where(c => c.Estado == request.FilterEstado.Value).ToList();
                }

                if (request.FilterIdCliente.HasValue)
                {
                    query = query.Where(c => c.Cliente.Id == request.FilterIdCliente.Value).ToList();
                }
                return query;
            }
        }
    }
}
