using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using CalculadoraService.Application.CalcularTaxaJurosUseCase;
using FluentAssertions;
using Moq;
using Xunit;

namespace CalculadoraService.UnitTests.Application.CalcularTaxaJurosUseCase
{
    public class CalcularTaxaJurosCommandHandlerTest
    {
        private readonly Mock<ITaxaJurosService> _taxaJurosServiceMock;

        public CalcularTaxaJurosCommandHandlerTest()
        {
            _taxaJurosServiceMock = new Mock<ITaxaJurosService>();
        }

        [Theory, AutoData]
        public async Task ReturnsValidDtoResultOnValidCommand([Range(0.001, 9999)] decimal valorInicial,
            [Range(0, 100)] int tempoMeses, [Range(0.001, 0.5)] decimal fakeTaxaJuros)
        {
            var fakeCommand = new CalcularTaxaJurosCommand(valorInicial, tempoMeses);
            _taxaJurosServiceMock.Setup(service => service.GetTaxaJurosAtual(new CancellationToken()))
                .Returns(Task.FromResult(fakeTaxaJuros));

            var handler = new CalcularTaxaJurosCommandHandler(_taxaJurosServiceMock.Object);
            var result = await handler.Handle(fakeCommand, new CancellationToken());

            result.Resultado.Should().NotBeEmpty();
        }
    }
}
