using JCP.Catalog.Application.Features.CatalogItems.Commands.Create;
using JCP.Catalog.Application.Interfaces.Repositories;
using JCP.Catalog.Domain.CatalogItemAggregate;
using JCP.Catalog.UnitTests.Common;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JCP.Catalog.UnitTests.Core.Features.CatalogItems.Commands
{
    public class CreateCatalogItemTests : BaseFixture
    {
        private Mock<IMediator> _mediator;
        private Mock<ICatalogItemRepository> _catalogRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;

        public CreateCatalogItemTests()
        {
            _mediator = new Mock<IMediator>();
            _catalogRepositoryMock = new Mock<ICatalogItemRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task CreateCatalogItem_Ok()
        {
            // Arrange
            _mediator.Setup(x => x.Send(It.IsAny<CreateCatalogItemCommand>(), default(CancellationToken)))
                .Returns(Task.FromResult(new CreateCatalogItemResponse()));

            _catalogRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<CatalogItem>()))
                .Returns(Task.FromResult(1));

            var handler = CreateSut();
            var cltToken = new CancellationToken();

            var fakeCatalogItemCmd = new CreateCatalogItemCommand
            {
                Barcode = "code-01",
                BrandId = 1,
                Description = "Bebida",
                Name = "Coca cola",
                Rate = 10
            };

            //Act
            var result = await handler.Handle(fakeCatalogItemCmd, cltToken);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Success);
        }

        private CreateCatalogItemCommandHandler CreateSut()
        {
            return new CreateCatalogItemCommandHandler(_catalogRepositoryMock.Object, _unitOfWorkMock.Object, _mapper);
        }
    }
}
