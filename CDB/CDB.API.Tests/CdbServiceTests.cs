using CDB.API.Models;
using CDB.API.Service;

namespace CDB.API.Tests
{
    public class CdbServiceTests
    {
        private readonly CdbService _service = new();

        [Fact]
        public void CalcularCdb_DeveRetornarValoresCorretos()
        {
            // Arrange
            var request = new CdbRequest { ValorInicial = 1000, PrazoMeses = 12 };

            // Act
            var result = _service.CalcularCdb(request);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.ValorBruto > 1000);
            Assert.True(result.ValorLiquido > 1000);
        }
    }
}
