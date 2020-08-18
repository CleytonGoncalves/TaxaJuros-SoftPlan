using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraService.Api.Configurations
{
    internal static class ApiVersioningExtensions
    {
        private const string VERSION_FORMAT = "'v'VVV"; // v'major[.minor][-status]

        public static IServiceCollection AddConfiguredApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options => options.ReportApiVersions = true);

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = VERSION_FORMAT;
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
