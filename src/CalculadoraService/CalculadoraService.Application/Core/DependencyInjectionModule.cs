using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CalculadoraService.Application.Core
{
    public static class DependencyInjectionModule
    {
        private static readonly Assembly THIS_ASSEMBLY = typeof(DependencyInjectionModule).Assembly;

        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddMediatR(THIS_ASSEMBLY);

            return services;
        }
    }
}
