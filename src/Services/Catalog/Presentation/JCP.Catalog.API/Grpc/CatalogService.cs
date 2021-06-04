using CatalogApi;
using Grpc.Core;
using JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
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
            var response = await _mediator.Send(new GetAllCatalogItemsQuery());

            return MapResponse(response);
        }

        private static GetAllCatalogItemsResponse1 MapResponse(GetAllCatalogItemsResponse response)
        {
            var result = new GetAllCatalogItemsResponse1();

            response.Items.ToList().ForEach(x => result.Items.Add(new CatalogItemsResponse()
            {
                Barcode = x.Barcode,
                BrandId = x.BrandId,
                Description = x.Description,
                Name = x.Name,
            }));

            return result;
        }
    }
}
