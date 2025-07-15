using Microsoft.EntityFrameworkCore;
using OfferManagement.Domain.Entities;

namespace OfferManagement.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Offer> Offers { get; }
        DbSet<Supplier> Suppliers { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
