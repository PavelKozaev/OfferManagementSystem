using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OfferManagement.Application.Common.Interfaces;
using OfferManagement.Application.DTOs;

namespace OfferManagement.Application.Features.Offers.Queries
{
    public record GetOffersWithSearchQuery(string? SearchTerm) : IRequest<PagedResultDto<OfferDto>>;

    public class GetOffersWithSearchQueryHandler : IRequestHandler<GetOffersWithSearchQuery, PagedResultDto<OfferDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOffersWithSearchQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<OfferDto>> Handle(GetOffersWithSearchQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Offers.Include(o => o.Supplier).AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                var term = request.SearchTerm.ToLower().Trim();
                query = query.Where(o =>
                    o.Brand.ToLower().Contains(term) ||
                    o.Model.ToLower().Contains(term) ||
                    o.Supplier.Name.ToLower().Contains(term));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var offers = await query
                .OrderByDescending(o => o.RegisteredAt)
                .ProjectTo<OfferDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PagedResultDto<OfferDto>
            {
                Items = offers,
                TotalCount = totalCount
            };
        }
    }
}
