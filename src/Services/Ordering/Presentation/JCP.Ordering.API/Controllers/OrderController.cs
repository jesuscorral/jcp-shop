using JCP.Ordering.Application.Features.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace JCP.Ordering.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger,
            IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
