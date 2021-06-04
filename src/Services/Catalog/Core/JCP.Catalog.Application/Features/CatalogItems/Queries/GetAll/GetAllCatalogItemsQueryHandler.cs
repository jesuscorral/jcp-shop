using AutoMapper;
using JCP.Catalog.Application.Features.CatalogItems.Queries.Dtos;
using JCP.Catalog.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll
{
    public class GetAllCatalogItemsQueryHandler : IRequestHandler<GetAllCatalogItemsQuery, GetAllCatalogItemsResponse>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;

        public GetAllCatalogItemsQueryHandler(ICatalogItemRepository catalogItemRepository,
            IMapper mapper)
        {
            _catalogItemRepository = catalogItemRepository ?? throw new ArgumentNullException(nameof(catalogItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetAllCatalogItemsResponse> Handle(GetAllCatalogItemsQuery request, CancellationToken cancellationToken)
        {
            // TODO - Improve automapper
            var catalogItems = await _catalogItemRepository.GetListAsync();
            var t = _mapper.Map<List<CatalogItemDto>>(catalogItems);

            return new GetAllCatalogItemsResponse { Items = t };
        }
    }
}
