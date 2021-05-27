using JCP.Catalog.API.Controllers;
using JCP.Catalog.Application.Features.CatalogItems.Commands.Create;
using JCP.Catalog.Application.Features.CatalogItems.Queries.GetAll;
using JCP.Catalog.UnitTests.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JCP.Catalog.UnitTests.Presentation.Controllers
{
    public class CatalogControllerTests : IClassFixture<BaseFixture>
    {
        private Mock<IMediator> _mediator;
        private Mock<ILogger<CatalogController>> _logger;

        private readonly BaseFixture _fixture;

        public CatalogControllerTests(BaseFixture fixture)
        {
            _fixture = fixture ?? throw new ArgumentNullException(nameof(_fixture));
        }

        [Fact]
        public async Task CreateCatalogItem_Ok()
        {
            // Arrange
            var sut = CreateSut();
            var mockRequest = new CreateCatalogItemCommand();
            _mediator.Setup(x => x.Send(It.IsAny<CreateCatalogItemCommand>(), new CancellationToken()))
                .Returns(Task.FromResult(new CreateCatalogItemResponse { Success = true }));

            // Act
            var ret = await sut.AddCatalogItem(mockRequest);

            // Assert
            Assert.IsType<OkObjectResult>(ret);
        }

        [Fact]
        public async Task GetCatalogItems_Ok()
        {
            // Arrange 
            var sut = CreateSut();
            _mediator.Setup(x => x.Send(It.IsAny<GetAllCatalogItemsQuery>(), new CancellationToken()))
                .Returns(Task.FromResult(new List<GetAllCatalogItemsResponse> { new GetAllCatalogItemsResponse() }));
            // Act
            var ret = await sut.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(ret);
        }

        private CatalogController CreateSut()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<CatalogController>>();

            return new CatalogController(_mediator.Object, _logger.Object);
        }
    }
}
