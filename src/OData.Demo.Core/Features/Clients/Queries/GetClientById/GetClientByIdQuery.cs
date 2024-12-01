using MediatR;
using OData.Demo.Core.Common.Models;
using OData.Demo.Core.Features.Clients.Models;

namespace OData.Demo.Core.Features.Clients.Queries.GetClientById
{
    public record GetClientByIdQuery : IRequest<Result<ClientDto>>
    {
        public int Id { get; init; }
    }
}