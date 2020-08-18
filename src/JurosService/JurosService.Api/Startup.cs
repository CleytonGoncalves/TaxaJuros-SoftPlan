using JurosService.Api.Configurations;
using JurosService.Api.Configurations.Swagger;
using JurosService.Api.Domain.TaxasJuros;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace JurosService.Api
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

            services.AddOptions<TaxaJurosOptions>().Bind(Configuration.GetSection(TaxaJurosOptions.SETTINGS_KEY));
            services.AddScoped<ITaxaJurosService, TaxaJurosService>();
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
