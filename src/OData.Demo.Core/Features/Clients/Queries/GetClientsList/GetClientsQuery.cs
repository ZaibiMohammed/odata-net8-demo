using MediatR;
using OData.Demo.Core.Common.Models;
using OData.Demo.Core.Features.Clients.Models;

namespace OData.Demo.Core.Features.Clients.Queries.GetClientsList
{
    public record GetClientsQuery : IRequest<Result<List<ClientDto>>>
    {
        public bool IncludeInactive { get; init; }
    }
}