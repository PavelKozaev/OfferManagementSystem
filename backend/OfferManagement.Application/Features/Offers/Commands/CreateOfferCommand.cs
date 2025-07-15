using MediatR;
using OfferManagement.Application.Common.Interfaces;
using OfferManagement.Domain.Entities;

namespace OfferManagement.Application.Features.Offers.Commands
{
    public record CreateOfferCommand(string Brand, string Model, int SupplierId) : IRequest<int>;

    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateOfferCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = new Offer
            {
                Brand = request.Brand,
                Model = request.Model,
                SupplierId = request.SupplierId,
                RegisteredAt = DateTime.UtcNow
            };

            await _context.Offers.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
