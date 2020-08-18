using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using CalculadoraService.Application.BuscarInformacaoCodigoUseCase;
using CalculadoraService.Infra.InformacaoCodigoServices;
using FluentAssertions;
using Xunit;

namespace CalculadoraService.UnitTests.Infra.InformacaoCodigoServices
{
    public class InformacaoCodigoServiceTest
    {
        [Fact]
        public void ThrowsExceptionGivenNullUrl()
        {
            var optionsWithNullUrl =
                OptionsHelper.CreateOptionSnapshotMock(new InformacaoCodigoOptions { Url = null! });

            Func<IInformacaoCodigoService> sut = () => new InformacaoCodigoService(optionsWithNullUrl);

            sut.Should().Throw<Exception>();
        }

        [Theory, AutoData]
        public async Task ReturnsCorrectValueFromSettings(Uri expectedUrl)
        {
            var options = OptionsHelper.CreateOptionSnapshotMock(new InformacaoCodigoOptions { Url = expectedUrl.ToString() });
            var sut = new InformacaoCodigoService(options);

            Uri result = await sut.GetRepositorioUrl(new CancellationToken());

            result.Should().Be(expectedUrl);
        }
    }
}
