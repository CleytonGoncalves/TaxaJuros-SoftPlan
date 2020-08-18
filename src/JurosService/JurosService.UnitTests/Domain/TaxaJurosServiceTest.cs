using System;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using FluentAssertions;
using JurosService.Api.Domain.TaxasJuros;
using Xunit;

namespace JurosService.Api.UnitTests.Domain
{
    public class TaxaJurosServiceTest
    {
        [Fact]
        public void ThrowsExceptionGivenNullValue()
        {
            var optionsWithValorNull = OptionsHelper.CreateOptionSnapshotMock(new TaxaJurosOptions { Valor = null });

            Func<TaxaJurosService> sut = () => new TaxaJurosService(optionsWithValorNull);

            sut.Should().Throw<Exception>();
        }

        [Theory, AutoData]
        public async Task ReturnsCorrectValue(decimal valor)
        {
            var options = OptionsHelper.CreateOptionSnapshotMock(new TaxaJurosOptions { Valor = valor });
            var sut = new TaxaJurosService(options);

            decimal result = await sut.GetTaxaAtual();

            result.Should().Be(valor);
        }
    }
}
