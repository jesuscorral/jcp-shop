using JCP.Ordering.BFF.Config;
using JCP.Ordering.BFF.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JCP.Ordering.BFF.Services
{
    public class OrderApiClient : IOrderApiClient
    {
        private readonly HttpClient _apiClient;
        private readonly ILogger<OrderApiClient> _logger;
        private readonly UrlsConfig _urls;

        public OrderApiClient(HttpClient apiClient,
            ILogger<OrderApiClient> logger,
            IOptions<UrlsConfig> config)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _urls = config.Value;
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            var url = _urls.Orders + UrlsConfig.OrdersOperations.CreateOrder();
            var content = new StringContent(JsonConvert.SerializeObject(request), System.Text.Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            var ordersDraftResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CreateOrderResponse>(ordersDraftResponse);
        }
    }
}
