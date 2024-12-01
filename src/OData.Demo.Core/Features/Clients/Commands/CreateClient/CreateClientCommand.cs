using MediatR;
using OData.Demo.Core.Common.Models;

namespace OData.Demo.Core.Features.Clients.Commands.CreateClient
{
    public record CreateClientCommand : IRequest<Result<int>>
    {
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Phone { get; init; } = string.Empty;
    }
}