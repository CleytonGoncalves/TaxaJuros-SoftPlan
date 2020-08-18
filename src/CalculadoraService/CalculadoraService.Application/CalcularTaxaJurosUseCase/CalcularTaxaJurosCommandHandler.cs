using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using CalculadoraService.Domain;
using MediatR;

namespace CalculadoraService.Application.CalcularTaxaJurosUseCase
{
    public class CalcularTaxaJurosCommandHandler : IRequestHandler<CalcularTaxaJurosCommand, CalculoTaxaJurosDto>
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalcularTaxaJurosCommandHandler(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public async Task<CalculoTaxaJurosDto> Handle(CalcularTaxaJurosCommand request, CancellationToken cancellationToken)
        {
            decimal taxaAtual = await _taxaJurosService.GetTaxaJurosAtual(cancellationToken);

            var taxaJuros = new CalculoTaxaJuros(request.ValorInicial, request.TempoMeses, taxaAtual);

            return new CalculoTaxaJurosDto(taxaJuros.GetResultadoFormatted(2, CultureInfo.CurrentUICulture));
        }
    }
}
