using JCP.Catalog.Application.Interfaces.Repositories;
using JCP.Catalog.Domain.CatalogItemAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JCP.Catalog.Infrastructure.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly CatalogContext _catalogContext;

        public CatalogItemRepository(CatalogContext catalogContext)
        {
            _catalogContext = catalogContext ?? throw new ArgumentNullException(nameof(catalogContext));
        }

        public async Task<int> InsertAsync(CatalogItem catalogItem)
        {
            await _catalogContext.AddAsync(catalogItem);
            return catalogItem.Id;
        }

        public async Task<List<CatalogItem>> GetListAsync()
        {
            return await _catalogContext.CatalogItems.ToListAsync();
        }

        public async Task<CatalogItem> GetByIdAsync(int id)
        {
            return await _catalogContext.CatalogItems.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
