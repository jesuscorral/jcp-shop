using AutoMapper;
using JCP.Catalog.Application.Features.CatalogItems.Queries.Dtos;
using JCP.Catalog.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Features.CatalogItems.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, CatalogItemDto>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(ICatalogItemRepository catalogItemRepository,
             IMapper mapper)
        {
            _catalogItemRepository = catalogItemRepository ?? throw new ArgumentNullException(nameof(catalogItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CatalogItemDto> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var catalogItem = await _catalogItemRepository.GetByIdAsync(request.CatalogItemId);
            return _mapper.Map<CatalogItemDto>(catalogItem);
        }
    }
}
