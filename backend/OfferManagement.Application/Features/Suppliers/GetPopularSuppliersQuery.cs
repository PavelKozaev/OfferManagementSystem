using MediatR;
using Microsoft.EntityFrameworkCore;
using OfferManagement.Application.Common.Interfaces;
using OfferManagement.Application.DTOs;

namespace OfferManagement.Application.Features.Suppliers
{
    public record GetPopularSuppliersQuery : IRequest<List<PopularSupplierDto>>;

    public class GetPopularSuppliersQueryHandler : IRequestHandler<GetPopularSuppliersQuery, List<PopularSupplierDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetPopularSuppliersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PopularSupplierDto>> Handle(GetPopularSuppliersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Suppliers
                .AsNoTracking() 
                .Select(s => new PopularSupplierDto
                {
                    Name = s.Name,
                    OffersCount = s.Offers.Count()
                })
                .OrderByDescending(s => s.OffersCount)
                .Take(3)
                .ToListAsync(cancellationToken);
        }
    }
}
