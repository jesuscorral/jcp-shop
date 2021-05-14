using JCP.Catalog.Application.Features.Catalogs.Commands.Create;
using Microsoft.AspNetCore.Mvc;
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
    }
}