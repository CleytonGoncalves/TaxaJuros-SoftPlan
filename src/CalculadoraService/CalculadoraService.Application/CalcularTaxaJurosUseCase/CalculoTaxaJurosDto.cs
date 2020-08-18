using System.Globalization;
using CalculadoraService.Domain;

namespace CalculadoraService.Application.CalcularTaxaJurosUseCase
{
    public class CalculoTaxaJurosDto
    {
        public string Resultado { get; }

        public CalculoTaxaJurosDto(string resultado)
        {
            Resultado = resultado;
        }
    }
}
