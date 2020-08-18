using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraService.Api.Configurations.Swagger
{
    internal static class SwaggerExtensions
    {
        public static IServiceCollection AddConfiguredSwagger(this IServiceCollection services)
        {
            services.ConfigureOptions<SwaggerUiOptions>();

            services.AddSwaggerGen(options => options.IncludeXmlComments(GenerateXmlCommentsFilePath()));

            return services;
        }

        public static IApplicationBuilder UseVersionedSwagger(this IApplicationBuilder app,
            IApiVersionDescriptionProvider? versionProvider)
        {
            if (versionProvider == null)
                throw new ArgumentNullException(nameof(versionProvider));

            app.UseSwagger();

            // Ordenado por versão p/ que a mais nova seja exibida como padrão
            var apiVersionDescriptions = versionProvider.ApiVersionDescriptions
                .OrderByDescending(x => x.ApiVersion.MajorVersion)
                .ThenByDescending(x => x.ApiVersion.MinorVersion);

            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                }

                options.RoutePrefix = string.Empty; // Deixa o swagger na rota raiz
            });

            return app;
        }

        private static string GenerateXmlCommentsFilePath()
        {
            string basePath = AppContext.BaseDirectory;
            string fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";

            return Path.Combine(basePath, fileName);
        }

    }
}
