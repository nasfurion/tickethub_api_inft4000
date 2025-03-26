using Microsoft.AspNetCore.Mvc;

namespace TicketHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly ILogger<PurchaseController> _logger;
        private readonly IConfiguration _configuration;

        public PurchaseController(ILogger<PurchaseController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Post(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                // Save the purchase to the database
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
