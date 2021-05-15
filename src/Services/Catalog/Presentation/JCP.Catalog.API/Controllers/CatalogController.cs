using JCP.Catalog.Application.Features.Catalogs.Commands.Create;
using JCP.Catalog.Application.Features.Catalogs.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace JCP.Catalog.API.Controllers
{
    public class CatalogController : BaseApiController<CatalogController>
    {
        [Route("catalog-item")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody] CreateCatalogItemCommand command)
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