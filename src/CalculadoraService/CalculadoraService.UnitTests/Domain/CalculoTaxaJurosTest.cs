using CalculadoraService.Domain;
using FluentAssertions;
using Xunit;

namespace CalculadoraService.UnitTests.Domain
{
    public class CalculoTaxaJurosTest
    {
        private const double MAX_DOUBLE_DIFF = 0.01;

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(1, 0, 0, 1)]
        [InlineData(1000, 36, 0.105, 36395.02)]
        public void ReturnsCorrectResultOnCalculoTaxaJuros(decimal valorInicial, int tempoMeses, decimal taxaJuros, decimal resultadoEsperado)
        {
            var sut = new CalculoTaxaJuros(valorInicial, tempoMeses, taxaJuros);

            double result = (double) sut.Resultado;

            result.Should().BeApproximately((double) resultadoEsperado, MAX_DOUBLE_DIFF);
        }
    }
}
