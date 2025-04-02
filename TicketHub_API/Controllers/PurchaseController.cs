using System.Text;
using System.Text.Json;
using Azure.Storage.Queues;
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
        public async Task<IActionResult> Post(Purchase purchase)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return BadRequest(ModelState);
                }

                string queueName = "tickethub";

                // Get connection string from secrets.json
                string? connectionString = _configuration["AzureStorageConnectionString"];

                if (string.IsNullOrEmpty(connectionString))
                {
                    return BadRequest("An error was encountered");
                }

                QueueClient queueClient = new QueueClient(connectionString, queueName);

                //Serialize object to json
                string message = JsonSerializer.Serialize(purchase);

                // send string message to queue (must encode as base64 to work properly)
                var plainTextBytes = Encoding.UTF8.GetBytes(message);
                var base64Message = Convert.ToBase64String(plainTextBytes);
                await queueClient.SendMessageAsync(base64Message);

                return Ok("Hello " + purchase.name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the purchase.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}
