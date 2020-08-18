using System;
using System.Threading;
using System.Threading.Tasks;
using CalculadoraService.Application.BuscarInformacaoCodigoUseCase;
using Microsoft.Extensions.Options;

namespace CalculadoraService.Infra.InformacaoCodigoServices
{
    public class InformacaoCodigoService : IInformacaoCodigoService
    {
        private readonly Uri _url;

        public InformacaoCodigoService(IOptionsSnapshot<InformacaoCodigoOptions> options)
        {
            if (options.Value == null || string.IsNullOrEmpty(options.Value.Url))
                throw new ArgumentException("Configuração do serviço de informação do código não encontrada", nameof(options));

            _url = new Uri(options.Value.Url);
        }

        public Task<Uri> GetRepositorioUrl(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(_url);
        }
    }
}
