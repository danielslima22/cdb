using MediatR;
using CDB.API.Models;
using CDB.API.Service;
using Microsoft.Extensions.Logging;
using CDB.API.Application.Queries;

namespace CDB.API.Application.Handlers
{
    public class CalcularCdbQueryHandler : IRequestHandler<CalcularCdbQuery, CdbResponse>
    {
        private readonly ICdbService _cdbService;
        private readonly ILogger<CalcularCdbQueryHandler> _logger;

        public CalcularCdbQueryHandler(ICdbService cdbService, ILogger<CalcularCdbQueryHandler> logger)
        {
            _cdbService = cdbService;
            _logger = logger;
        }

        public async Task<CdbResponse> Handle(CalcularCdbQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processando Query para calcular CDB: ValorInicial={ValorInicial}, PrazoMeses={PrazoMeses}",
                request.ValorInicial, request.PrazoMeses);

            try
            {
                var resultado = _cdbService.CalcularCdb(new CdbRequest
                {
                    ValorInicial = request.ValorInicial,
                    PrazoMeses = request.PrazoMeses
                });

                _logger.LogInformation("Cálculo do CDB realizado com sucesso: ValorBruto={ValorBruto}, ValorLiquido={ValorLiquido}",
                    resultado.ValorBruto, resultado.ValorLiquido);

                return await Task.FromResult(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar Query de cálculo do CDB.");
                throw;
            }
        }
    }
}
