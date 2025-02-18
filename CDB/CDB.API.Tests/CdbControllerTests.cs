using CDB.API.Controllers;
using CDB.API.Models;
using CDB.API.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CDB.API.Tests
{
    public class CdbControllerTests
    {
        private readonly Mock<ICdbService> _mockService;
        private readonly CdbController _controller;

        public CdbControllerTests()
        {
            _mockService = new Mock<ICdbService>(); 
            _controller = new CdbController(_mockService.Object);
        }

        [Fact]
        public void CalcularCdb_ComDadosValidos_DeveRetornarOk()
        {
            // Arrange
            var request = new CdbRequest { ValorInicial = 1000, PrazoMeses = 12 };
            var expectedResult = new CdbResponse { ValorBruto = 1200, ValorLiquido = 1100 };

            _mockService.Setup(s => s.CalcularCdb(request)).Returns(expectedResult);

            // Act
            var result = _controller.CalcularCdb(request) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public void CalcularCdb_ComDadosInvalidos_DeveRetornarBadRequest()
        {
            // Act
            var result = _controller.CalcularCdb(null) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }
    }
}
