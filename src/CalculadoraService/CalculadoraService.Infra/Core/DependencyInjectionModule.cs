using CalculadoraService.Application.BuscarInformacaoCodigoUseCase;
using CalculadoraService.Application.CalcularTaxaJurosUseCase;
using CalculadoraService.Infra.InformacaoCodigoServices;
using CalculadoraService.Infra.TaxaJurosServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraService.Infra.Core
{
    public static class DependencyInjectionModule
    {
        public static IServiceCollection AddInfraDependencyInjection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<InformacaoCodigoOptions>().Bind(configuration.GetSection(InformacaoCodigoOptions.SETTINGS_KEY));
            services.AddScoped<IInformacaoCodigoService, InformacaoCodigoService>();

            services.AddOptions<TaxaJurosOptions>().Bind(configuration.GetSection(TaxaJurosOptions.SETTINGS_KEY));
            services.AddHttpClient<ITaxaJurosService, TaxaJurosService>();

            return services;
        }
    }
}
