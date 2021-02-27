using JCP.Ordering.API.Controllers;
using Microsoft.Extensions.Logging;
using Xunit;

namespace JCP.Ordering.API.Tests.Controllers
{
    public class WeatherForecastControllerTest
    {
        private readonly ILogger<WeatherForecastController> _logger;


        [Fact]
        public void Test1()
        {
            // Arrange 
            var wController = new WeatherForecastController(_logger);

            // Act
            var ret = wController.Get();

            // Assert

            Assert.NotNull(ret);
        }
    }
}
