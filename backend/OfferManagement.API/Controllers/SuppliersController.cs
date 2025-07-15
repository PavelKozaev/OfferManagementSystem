using Microsoft.AspNetCore.Mvc;
using OfferManagement.Application.Features.Suppliers;

namespace OfferManagement.API.Controllers
{
    public class SuppliersController : BaseApiController
    {
        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularSuppliers()
        {
            var result = await Mediator.Send(new GetPopularSuppliersQuery());
            return Ok(result);
        }
    }
}
