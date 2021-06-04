using CatalogApi;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace JCP.Ordering.BFF.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly Catalog.CatalogClient _client;
        private readonly ILogger<CatalogService> _logger;


        public CatalogService(Catalog.CatalogClient client, ILogger<CatalogService> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<GetAllCatalogItemsResponse1> GetCatalogItemAsync(CatalogItemsRequest request)
        {
            return await _client.GetCatalogItemsAsync(request);
        }
    }
}
