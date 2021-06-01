using JCP.Ordering.BFF.Models;
using JCP.Ordering.BFF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JCP.Ordering.BFF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICatalogService _catalogService;

        public OrderController(ILogger<OrderController> logger, ICatalogService catalogService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _catalogService = catalogService ?? throw new ArgumentNullException(nameof(catalogService));
        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            if (request == null)
            {
                return BadRequest("Error");
            }

            var catalogItems = await _catalogService.GetCatalogItemAsync();
            if (catalogItems != null)
            {
                request.Status = OrderStatus.AwaitingStockValidation;
                // TODO - Call to JCP.Order.API throw postAync without convert to grpc service
            }
            return Ok();
        }
    }
}
