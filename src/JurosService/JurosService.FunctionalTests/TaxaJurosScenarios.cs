using System.Threading.Tasks;
using Xunit;

namespace JurosService.FunctionalTests
{
    public class JurosScenarios : JurosScenarioBase
    {
        [Fact]
        public async Task ReturnsSuccessStatusCodeOnGetTaxaJuros()
        {
            using (var server = CreateServer())
            {
                var client = server.CreateClient();

                var response = await client.GetAsync(Get.TaxaJuros);

                response.EnsureSuccessStatusCode();
            }
        }
    }
}
