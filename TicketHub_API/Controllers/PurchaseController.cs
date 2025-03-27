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
            //if (string.IsNullOrEmpty(contact.FirstName) || string.IsNullOrEmpty(contact.LastName))
            //    return BadRequest("First and last names are required");

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

            string message = JsonSerializer.Serialize(purchase);

            await queueClient.SendMessageAsync(message);

            return Ok("Hello" + purchase.name);
        }
    }
}
