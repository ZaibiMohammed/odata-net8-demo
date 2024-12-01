using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OData.Demo.Core.Common.Models;
using OData.Demo.Core.Features.Clients.Models;
using OData.Demo.Core.Interfaces;

namespace OData.Demo.Core.Features.Clients.Queries.GetClientsList
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, Result<List<ClientDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<List<ClientDto>>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Clients.AsQueryable();

            if (!request.IncludeInactive)
            {
                query = query.Where(x => x.IsActive);
            }

            var clients = await query
                .OrderBy(x => x.Name)
                .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return Result<List<ClientDto>>.Success(clients);
        }
    }
}