using System.Threading.Tasks;

namespace JurosService.Api.Domain.TaxasJuros
{
    public interface ITaxaJurosService
    {
        Task<decimal> GetTaxaAtual();
    }
}
