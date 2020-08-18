using System;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace JurosService.Api.Configurations.Swagger
{
    internal class SwaggerUiOptions: IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _versionProvider;

        public SwaggerUiOptions(IApiVersionDescriptionProvider versionProvider)
        {
            _versionProvider = versionProvider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            // Cria um documento do swagger p/ cada versão da API
            foreach (var description in _versionProvider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            // Idealmente essas informações viriam do appsettings
            var info = new OpenApiInfo
            {
                Title = "Juros API",
                Description = "Desafio Técnico SoftPlan",
                Version = description.ApiVersion.ToString(),
                Contact = new OpenApiContact
                {
                    Name = "Cleyton Gonçalves",
                    Email = "cleyton@cleytongoncalves.com",
                    Url = new Uri("https://cleytongoncalves.com")
                },
            };

            if (description.IsDeprecated)
                info.Description += " [Deprecated Version]";

            return info;
        }
    }
}
