using CatalogApi;
using JCP.Ordering.BFF.Models;
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

        public async Task<CatalogItem> GetCatalogItemAsync()
        {
            var request = new CatalogItemsRequest();
            var response = await _client.GetCatalogItemsAsync(request);

            return new CatalogItem();
        }
    }
}
