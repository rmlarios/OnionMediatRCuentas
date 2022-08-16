﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Exceptions;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Specifications;
using ApplicationC.Wrappers;
using AutoMapper;
using Domain;
using MediatR;

namespace ApplicationC.Features.MovimientoFeatures.Queries.GetAllMovimientos
{
    public class GetAllMovimientosQuery : RequestSpecification, IRequest<PagedResponse<IEnumerable<MovimientoDto>>>
    {
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }

        public class GetAllMovimientosQueryHandler : IRequestHandler<GetAllMovimientosQuery, PagedResponse<IEnumerable<MovimientoDto>>>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly IMapper _mapper;
            public GetAllMovimientosQueryHandler(IMovimientoRepository movimientoRepository, IMapper mapper)
            {
                _movimientoRepository = movimientoRepository;
                _mapper = mapper;
            }
            public async Task<PagedResponse<IEnumerable<MovimientoDto>>> Handle(GetAllMovimientosQuery request, CancellationToken cancellationToken)
            {
                var spec = _mapper.Map<GetAllMovimientosSpecification>(request);
                var movimientos = await _movimientoRepository.GetPagedReponseAsync(spec.PageNumber, spec.PageSize, "Cuenta");
                var movimientosDto = _mapper.Map<IEnumerable<MovimientoDto>>(movimientos);
                return new PagedResponse<IEnumerable<MovimientoDto>>(movimientosDto, spec.PageNumber, spec.PageSize);
            }

        }
    }
}
