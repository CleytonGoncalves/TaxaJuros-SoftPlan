using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace JurosService.Api.Domain.TaxasJuros
{
    public class TaxaJurosService : ITaxaJurosService
    {
        private readonly decimal _taxaAtual;

        public TaxaJurosService(IOptionsSnapshot<TaxaJurosOptions> options)
        {
            if (options.Value?.Valor == null)
                throw new ArgumentException("Valor da taxa de juros não encontrada", nameof(options));

            _taxaAtual = options.Value.Valor.Value;
        }

        public Task<decimal> GetTaxaAtual()
        {
            return Task.FromResult(_taxaAtual);
        }
    }
}
