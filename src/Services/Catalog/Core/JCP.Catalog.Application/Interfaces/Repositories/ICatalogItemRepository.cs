using JCP.Catalog.Domain.CatalogItemAggregate;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Interfaces.Repositories
{
    public interface ICatalogItemRepository
    {
        Task<int> InsertAsync(CatalogItem buyer);
    }
}
