using System.IO;
using System.Reflection;
using JurosService.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace JurosService.FunctionalTests
{
    public class JurosScenarioBase
    {
        public TestServer CreateServer()
        {
            string path = Assembly.GetAssembly(typeof(JurosScenarioBase))!.Location;

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
            public static string TaxaJuros = "v1/TaxaJuros";
        }
    }
}
