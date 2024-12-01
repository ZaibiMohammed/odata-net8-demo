using Microsoft.EntityFrameworkCore;
using OData.Demo.Core.Entities;

namespace OData.Demo.Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Client> Clients { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}