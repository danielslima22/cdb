using Microsoft.AspNetCore.Mvc;
using MediatR;
using CDB.API.Application.Queries;
using CDB.API.Models;

namespace CDB.API.Controllers
{
    [Route("api/cdb")]
    [ApiController]
    public class CdbController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CdbController> _logger;

        public CdbController(IMediator mediator, ILogger<CdbController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> CalcularCdb([FromBody] CalcularCdbQuery request)
        {
            if (request == null || request.ValorInicial <= 0 || request.PrazoMeses < 1)
            {
                _logger.LogWarning("Requisição inválida recebida para cálculo de CDB.");
                return BadRequest("Os valores informados são inválidos.");
            }

            try
            {
                _logger.LogInformation("Iniciando cálculo do CDB para ValorInicial: {ValorInicial}, PrazoMeses: {PrazoMeses}",
                    request.ValorInicial, request.PrazoMeses);

                var resultado = await _mediator.Send(request);

                _logger.LogInformation("Cálculo do CDB concluído com sucesso para ValorInicial: {ValorInicial}, PrazoMeses: {PrazoMeses}",
                    request.ValorInicial, request.PrazoMeses);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular CDB.");
                return StatusCode(500, "Erro interno ao calcular o CDB.");
            }
        }
    }
}
