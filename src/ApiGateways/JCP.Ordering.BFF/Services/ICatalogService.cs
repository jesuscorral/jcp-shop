using JCP.Ordering.BFF.Models;
using System.Threading.Tasks;

namespace JCP.Ordering.BFF.Services
{
    public interface ICatalogService
    {
        Task<CatalogItem> GetCatalogItemAsync();
    }
}
