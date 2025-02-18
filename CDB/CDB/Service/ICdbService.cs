using CDB.API.Models;

namespace CDB.API.Service
{
    public interface ICdbService
    {
        CdbResponse CalcularCdb(CdbRequest request);
    }
}
