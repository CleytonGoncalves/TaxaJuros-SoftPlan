using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using CalculadoraService.Application.CalcularTaxaJurosUseCase;
using CalculadoraService.Infra.TaxaJurosServices;
using FluentAssertions;
using Moq;
using Xunit;

namespace CalculadoraService.UnitTests.Infra.TaxaJurosServices
{
    public class TaxaJurosServiceTest
    {
        [Fact]
        public void ThrowsExceptionGivenNullUrl()
        {
            var httpClientMock = new Mock<HttpClient>();
            var optionsWithValorNull = OptionsHelper.CreateOptionSnapshotMock(new TaxaJurosOptions { Url = null! });

            Func<ITaxaJurosService> sut = () => new TaxaJurosService(httpClientMock.Object, optionsWithValorNull);

            sut.Should().Throw<Exception>();
        }

        [Theory, AutoData]
        public async Task GetsCorrectValueFromRemoteService(Uri fakeUrl, decimal expectedResult)
        {
            var expedResultAsStr = expectedResult.ToString(CultureInfo.InvariantCulture);
            var httpClient = new HttpClient(HttpMessageHandlerHelper.MockMessageHandler(expedResultAsStr).Object);
            var options = OptionsHelper.CreateOptionSnapshotMock(new TaxaJurosOptions { Url = fakeUrl.ToString() });
            var sut = new TaxaJurosService(httpClient, options);

            decimal result = await sut.GetTaxaJurosAtual();

            sut.RemoteUri.Should().Be(fakeUrl);
            result.Should().Be(expectedResult);
        }
    }
}
