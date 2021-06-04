using CatalogApi;
using System.Threading.Tasks;

namespace JCP.Ordering.BFF.Services
{
    public interface ICatalogService
    {
        Task<GetAllCatalogItemsResponse1> GetCatalogItemAsync(CatalogItemsRequest request);
    }
}
