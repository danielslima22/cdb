using CDB.API.Models;

namespace CDB.API.Service
{
    public class CdbService : ICdbService
    {
        private const decimal TB = 1.08m; // 108%
        private const decimal CDI = 0.009m; // 0.9%

        public CdbResponse CalcularCdb(CdbRequest request)
        {
            decimal valorFinal = request.ValorInicial;

            for (int i = 0; i < request.PrazoMeses; i++)
            {
                valorFinal *= (1 + (CDI * TB));
            }

            decimal imposto = CalcularImposto(valorFinal - request.ValorInicial, request.PrazoMeses);
            decimal valorLiquido = valorFinal - imposto;

            return new CdbResponse
            {
                ValorBruto = valorFinal,
                ValorLiquido = valorLiquido
            };
        }

        private decimal CalcularImposto(decimal lucro, int prazo)
        {
            decimal taxaImposto =
                prazo <= 6 ? 0.225m :
                prazo <= 12 ? 0.20m :
                prazo <= 24 ? 0.175m :
                0.15m;

            return lucro * taxaImposto;
        }
    }

}
