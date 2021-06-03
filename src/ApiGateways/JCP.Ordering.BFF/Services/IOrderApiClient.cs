using JCP.Ordering.BFF.Models;
using System.Threading.Tasks;

namespace JCP.Ordering.BFF.Services
{
    public interface IOrderApiClient
    {
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request);
    }
}
