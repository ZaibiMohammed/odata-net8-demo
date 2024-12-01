using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OData.Demo.Core.Common.Models;
using OData.Demo.Core.Features.Clients.Models;
using OData.Demo.Core.Interfaces;

namespace OData.Demo.Core.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Result<ClientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<ClientDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (client == null)
            {
                return Result<ClientDto>.Failure($"Client with ID {request.Id} not found.");
            }

            return Result<ClientDto>.Success(_mapper.Map<ClientDto>(client));
        }
    }
}