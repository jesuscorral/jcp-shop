using JCP.Catalog.Domain.CatalogItemAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Interfaces.Repositories
{
    public interface ICatalogItemRepository
    {
        Task<int> InsertAsync(CatalogItem buyer);

        Task<List<CatalogItem>> GetListAsync();
    }
}
