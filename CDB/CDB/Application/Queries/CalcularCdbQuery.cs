using CDB.API.Models;
using MediatR;

namespace CDB.API.Application.Queries
{
    public class CalcularCdbQuery : IRequest<CdbResponse>
    {
        public decimal ValorInicial { get; set; }
        public int PrazoMeses { get; set; }

        public CalcularCdbQuery(decimal valorInicial, int prazoMeses)
        {
            ValorInicial = valorInicial;
            PrazoMeses = prazoMeses;
        }
    }
}
