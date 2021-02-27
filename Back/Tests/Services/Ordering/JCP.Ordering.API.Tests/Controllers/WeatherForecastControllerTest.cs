using JCP.Ordering.API.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace JCP.Ordering.API.Tests.Controllers
{
    public class WeatherForecastControllerTest
    {
        private readonly Mock<ILogger<WeatherForecastController>> _mockLogger;

        public WeatherForecastControllerTest()
        {
            _mockLogger = new Mock<ILogger<WeatherForecastController>>();
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