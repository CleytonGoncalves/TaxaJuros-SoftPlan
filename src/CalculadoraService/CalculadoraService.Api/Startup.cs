using CalculadoraService.Api.Configurations;
using CalculadoraService.Api.Configurations.Swagger;
using CalculadoraService.Application.Core;
using CalculadoraService.Infra.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace CalculadoraService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddConfiguredApiVersioning();
            services.AddConfiguredSwagger();
            services.AddApplicationDependencyInjection();
            services.AddInfraDependencyInjection(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IApiVersionDescriptionProvider apiVersionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSerilogRequestLogging(RequestLoggingOptions.Configure);

            app.UseRouting();

            app.UseVersionedSwagger(apiVersionProvider);

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
