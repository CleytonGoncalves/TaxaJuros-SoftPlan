using System.Threading;
using System.Threading.Tasks;

namespace CalculadoraService.Application.CalcularTaxaJurosUseCase
{
    public interface ITaxaJurosService
    {
        Task<decimal> GetTaxaJurosAtual(CancellationToken cancellationToken);
    }
}
