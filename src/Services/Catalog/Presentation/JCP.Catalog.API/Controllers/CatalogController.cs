using JCP.Catalog.Application.Features.CatalogItems.Commands.Create;
using JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace JCP.Catalog.API.Controllers
{
    public class CatalogController : BaseApiController<CatalogController>
    {
        private IMediator _mediator;
        private ILogger<CatalogController> _logger;

        public CatalogController(IMediator mediator, ILogger<CatalogController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        [Route("catalog-item")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCatalogItem([FromBody] CreateCatalogItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Route("all")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetAllCatalogItemsResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var catalogItems = await _mediator.Send(new GetAllCatalogItemsQuery());
            return Ok(catalogItems);
        }
    }
}