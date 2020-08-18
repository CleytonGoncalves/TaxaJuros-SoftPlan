using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CalculadoraService.Application.BuscarInformacaoCodigoUseCase
{
    public class BuscarInformacaoCodigoQueryHandler : IRequestHandler<BuscarInformacaoCodigoQuery, InformacaoCodigoDto>
    {
        private readonly IInformacaoCodigoService _informacaoCodigoService;

        public BuscarInformacaoCodigoQueryHandler(IInformacaoCodigoService informacaoCodigoService)
        {
            _informacaoCodigoService = informacaoCodigoService;
        }

        public async Task<InformacaoCodigoDto> Handle(BuscarInformacaoCodigoQuery request, CancellationToken cancellationToken)
        {
            var url = await _informacaoCodigoService.GetRepositorioUrl(cancellationToken);

            return new InformacaoCodigoDto(url.ToString());
        }
    }
}
