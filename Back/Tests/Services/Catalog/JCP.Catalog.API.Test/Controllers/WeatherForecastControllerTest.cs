using JCP.Catalog.API.Controllers;
using MediatR;
using Moq;
using Xunit;

namespace JCP.Catalog.API.Test.Controllers
{
    public class WeatherForecastControllerTest
        {
            private readonly Mock<IMediator> _mockLogger;

            public WeatherForecastControllerTest()
            {
                _mockLogger = new Mock<IMediator>();
            }

            [Fact]
            public void WeatherForecastController_Get_Ok()
            {
                // Arrange 
                var wController = CreateSut();

                // Act
                var ret = wController.Get();

                // Assert
                Assert.NotNull(ret);
            }

            private WeatherForecastController CreateSut()
            {
                return new WeatherForecastController(_mockLogger.Object);
            }
        }
}
