using System.IO;
using System.Reflection;
using CalculadoraService.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CalculadoraService.FunctionalTests
{
    public class CalculadoraScenarioBase
    {
        public TestServer CreateServer()
        {
            string path = Assembly.GetAssembly(typeof(CalculadoraScenarioBase))!.Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .UseSerilog()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                        .AddEnvironmentVariables();
                }).UseStartup<Startup>();

            var testServer = new TestServer(hostBuilder);

            return testServer;
        }

        public static class Get
        {
            public static string BuscarInformacaoCodigo = "v1/ShowMeTheCode";

            public static string CalcularTaxaJuros(decimal valorInicial, int meses)
            {
                return $"v1/CalculaJuros?{nameof(valorInicial)}={valorInicial}&{nameof(meses)}={meses}";
            }
        }
    }
}
