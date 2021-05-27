using JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll;
using JCP.Catalog.Application.Interfaces.Repositories;
using JCP.Catalog.Domain.CatalogItemAggregate;
using JCP.Catalog.UnitTests.Common;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JCP.Catalog.UnitTests.Core.Features.CatalogItems.Queries.GetAll
{
    public class GetAllCatalogItemsQueryTests : BaseFixture
    {
        private Mock<IMediator> _mediator;
        private Mock<ICatalogItemRepository> _catalogRepositoryMock;

        public GetAllCatalogItemsQueryTests()
        {
            _mediator = new Mock<IMediator>();
            _catalogRepositoryMock = new Mock<ICatalogItemRepository>();
        }

        [Fact]
        public async Task GetAllCatalogItems_ShouldReturnAllCatalogItems()
        {
            // Arrange
            _mediator.Setup(x => x.Send(It.IsAny<GetAllCatalogItemsQuery>(), default(CancellationToken)))
                 .Returns(Task.FromResult(new List<GetAllCatalogItemsResponse>()));

            var fakeCatalogItems = new List<CatalogItem>()
            { new CatalogItem { BrandId = 1} };

            _catalogRepositoryMock.Setup(x => x.GetListAsync())
                 .Returns(Task.FromResult(fakeCatalogItems));

            var handler = CreateSut();
            var fakeRequest = new GetAllCatalogItemsQuery();
            var cltToken = new CancellationToken();

            //Act
            var result = await handler.Handle(fakeRequest, cltToken);

            // Assert
            Assert.NotNull(result);
        }

        private GetAllCatalogItemsQueryHandler CreateSut()
        {
            return new GetAllCatalogItemsQueryHandler(_catalogRepositoryMock.Object, _mapper);
        }
    }
}
