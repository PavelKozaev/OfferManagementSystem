using Microsoft.AspNetCore.Mvc;
using OfferManagement.Application.Features.Offers.Commands;
using OfferManagement.Application.Features.Offers.Queries;

namespace OfferManagement.API.Controllers
{
    public class OffersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetOffers([FromQuery] string? searchTerm)
        {
            var result = await Mediator.Send(new GetOffersWithSearchQuery(searchTerm));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferCommand command)
        {
            var offerId = await Mediator.Send(command);
            return CreatedAtAction(nameof(CreateOffer), new { id = offerId }, command);
        }
    }
}
