using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CalculadoraService.Application.CalcularTaxaJurosUseCase;
using Microsoft.Extensions.Options;

namespace CalculadoraService.Infra.TaxaJurosServices
{
    public class TaxaJurosService : ITaxaJurosService
    {
        public Uri RemoteUri { get; }

        private readonly HttpClient _httpClient;

        public TaxaJurosService(HttpClient httpClient, IOptionsSnapshot<TaxaJurosOptions> options)
        {
            if (options.Value == null || string.IsNullOrEmpty(options.Value.Url))
                throw new ArgumentException("Configuração do serviço de taxa de juros não encontrada", nameof(options));

            _httpClient = httpClient;
            RemoteUri = new Uri(options.Value.Url);
        }

        public async Task<decimal> GetTaxaJurosAtual(CancellationToken cancellationToken = default)
        {
            Stream responseStream = await _httpClient.GetStreamAsync(RemoteUri);
            var taxaAtual = await JsonSerializer.DeserializeAsync<decimal>(responseStream, cancellationToken: cancellationToken);

            return taxaAtual;
        }
    }
}
