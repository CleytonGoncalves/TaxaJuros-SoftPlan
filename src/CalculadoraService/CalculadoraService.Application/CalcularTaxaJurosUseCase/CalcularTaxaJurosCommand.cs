using System.ComponentModel.DataAnnotations;
using MediatR;

namespace CalculadoraService.Application.CalcularTaxaJurosUseCase
{
    public sealed class CalcularTaxaJurosCommand : IRequest<CalculoTaxaJurosDto>
    {
        public decimal ValorInicial { get; }

        public int TempoMeses { get; }

        public CalcularTaxaJurosCommand(decimal valorInicial, int tempoMeses)
        {
            ValorInicial = valorInicial;
            TempoMeses = tempoMeses;
        }
    }
}
