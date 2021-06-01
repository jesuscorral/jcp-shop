using Microsoft.AspNetCore.Mvc;

namespace JCP.Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
    {
    }
}