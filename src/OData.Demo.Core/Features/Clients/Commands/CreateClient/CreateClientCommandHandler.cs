using MediatR;
using OData.Demo.Core.Common.Models;
using OData.Demo.Core.Entities;
using OData.Demo.Core.Interfaces;

namespace OData.Demo.Core.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Result<int>>
    {
        private readonly IApplicationDbContext _context;

        public CreateClientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<int>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = Client.Create(request.Name, request.Email, request.Phone);
            
            _context.Clients.Add(client);
            await _context.SaveChangesAsync(cancellationToken);

            return Result<int>.Success(client.Id);
        }
    }
}