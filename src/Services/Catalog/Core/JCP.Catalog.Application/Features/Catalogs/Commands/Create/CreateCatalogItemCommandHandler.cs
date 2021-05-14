using AutoMapper;
using JCP.Catalog.Application.Interfaces.Repositories;
using JCP.Catalog.Domain.CatalogItemAggregate;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Features.Catalogs.Commands.Create
{
    public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, CreateCatalogItemResponse>
    {
        private readonly ICatalogItemRepository _catalogItemRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateCatalogItemCommandHandler(ICatalogItemRepository catalogItemRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _catalogItemRepository = catalogItemRepository ?? throw new ArgumentNullException(nameof(catalogItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<CreateCatalogItemResponse> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            var catalogItem = _mapper.Map<CatalogItem>(request);
            await _catalogItemRepository.InsertAsync(catalogItem);
            await _unitOfWork.Commit(cancellationToken);

            return new CreateCatalogItemResponse
            {
                Success = true,
            };
        }
    }
}
