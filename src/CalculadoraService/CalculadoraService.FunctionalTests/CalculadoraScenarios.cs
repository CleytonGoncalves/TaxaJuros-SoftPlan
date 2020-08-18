using System.Threading.Tasks;
using Xunit;

namespace CalculadoraService.FunctionalTests
{
    public class CalculadoraScenarios : CalculadoraScenarioBase
    {
        [Fact]
        public async Task ReturnsSuccessStatusCodeOnBuscarInformacaoCodigo()
        {
            using (var server = CreateServer())
            {
                var client = server.CreateClient();

                var response = await client.GetAsync(Get.BuscarInformacaoCodigo);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
