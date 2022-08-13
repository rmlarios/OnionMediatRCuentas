using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApplicationC.Interfaces.Repositories;
using ApplicationC.Wrappers;
using AutoMapper;
using MediatR;

namespace ApplicationC.Features.ClienteFeatures.Queries.GetAllClients
{
    public class GetAllClientesQuery : IRequest<PagedResponse<IEnumerable<ClienteDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, PagedResponse<IEnumerable<ClienteDto>>>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public GetAllClientesQueryHandler(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<IEnumerable<ClienteDto>>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            var spec = _mapper.Map<GetAllClientesSpecification>(request);
            var clientes = await _clienteRepository.GetPagedReponseAsync(spec.PageNumber, spec.PageSize);
            var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);
            return new PagedResponse<IEnumerable<ClienteDto>>(clientesDto, spec.PageNumber, spec.PageSize);
        }
    }

}
