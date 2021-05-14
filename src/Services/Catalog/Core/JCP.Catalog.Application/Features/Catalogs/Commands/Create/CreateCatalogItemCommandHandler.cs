using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JCP.Catalog.Application.Features.Catalogs.Commands.Create
{
    public class CreateCatalogItemCommandHandler : IRequestHandler<CreateCatalogItemCommand, CreateCatalogItemResponse>
    {
        public CreateCatalogItemCommandHandler()
        {

        }

        public async Task<CreateCatalogItemResponse> Handle(CreateCatalogItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
