using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JCP.Catalog.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        public readonly IMediator _mediator;

        public BaseController(IMediator mediatR)
        {
            _mediator = mediatR ?? throw new ArgumentNullException(nameof(mediatR));
        }
    }
}
