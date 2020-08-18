using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using CalculadoraService.Application.BuscarInformacaoCodigoUseCase;
using FluentAssertions;
using Moq;
using Xunit;

namespace CalculadoraService.UnitTests.Application.BuscarInformacaoCodigoUseCase
{
    public class BuscarInformacaoCodigoQueryHandlerTest
    {
        private readonly Mock<IInformacaoCodigoService> _informacaoCodigoServiceMock;

        public BuscarInformacaoCodigoQueryHandlerTest()
        {
            _informacaoCodigoServiceMock = new Mock<IInformacaoCodigoService>();
        }

        [Theory, AutoData]
        public async Task ReturnsCorrectUrlOnQueryHandlerDtoResult(BuscarInformacaoCodigoQuery fakeQuery,
            Uri fakeRepositorioUrl)
        {
            _informacaoCodigoServiceMock.Setup(service => service.GetRepositorioUrl(new CancellationToken()))
                .Returns(Task.FromResult(fakeRepositorioUrl));

            var handler = new BuscarInformacaoCodigoQueryHandler(_informacaoCodigoServiceMock.Object);
            var result = await handler.Handle(fakeQuery, new CancellationToken());

            result.Url.Should().Be(fakeRepositorioUrl.ToString());
        }
    }
}
