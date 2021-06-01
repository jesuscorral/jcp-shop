using CatalogApi;
using Grpc.Core;
using JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static CatalogApi.Catalog;

namespace JCP.Catalog.API.Grpc
{
    public class CatalogService : CatalogBase
    {
        private readonly ILogger<CatalogService> _logger;
        private IMediator _mediator;

        public CatalogService(ILogger<CatalogService> logger,
                              IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public override async Task<GetAllCatalogItemsResponse1> GetCatalogItems(CatalogItemsRequest request, ServerCallContext context)
        {
            var t = new GetAllCatalogItemsResponse1();
            var catalogItems = await _mediator.Send(new GetAllCatalogItemsQuery());
            return t;
        }
    }
}
