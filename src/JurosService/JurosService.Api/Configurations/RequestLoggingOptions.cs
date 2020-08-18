using System;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;

namespace JurosService.Api.Configurations
{
    internal static class RequestLoggingOptions
    {
        private const string MESSAGE_TEMPLATE =
            "HTTP {RequestMethod} to '{Path}' responded with {StatusCode} in {Elapsed:0} ms";

        public static void Configure(Serilog.AspNetCore.RequestLoggingOptions? options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            options.MessageTemplate = MESSAGE_TEMPLATE;
            options.GetLevel = GetRequestLogLevel;
            options.EnrichDiagnosticContext = EnrichRequest;
        }

        private static LogEventLevel GetRequestLogLevel(HttpContext httpCtx, double elapsedMs, Exception? ex)
        {
            const string serviceWorkerPath = "/service-worker.js";

            if (ex != null || httpCtx.Response.StatusCode >= StatusCodes.Status500InternalServerError)
                return LogEventLevel.Error;

            if (httpCtx.Request.Path.Value == serviceWorkerPath ||
                httpCtx.Request.Method.Equals(HttpMethod.Options.Method, StringComparison.OrdinalIgnoreCase))
            {
                return LogEventLevel.Verbose;
            }

            return LogEventLevel.Information;
        }

        private static void EnrichRequest(IDiagnosticContext diagnosticCtx, HttpContext httpCtx)
        {
            diagnosticCtx.Set("IpAddress", httpCtx.Connection?.RemoteIpAddress?.ToString() ?? "- Unknown -");
            diagnosticCtx.Set("User", httpCtx.User?.Identity.Name ?? "- Unauthenticated -");

            if (httpCtx.Request.Path.HasValue)
                diagnosticCtx.Set("Path", httpCtx.Request.Path.Value);

            if (httpCtx.Request.QueryString.HasValue)
                diagnosticCtx.Set("QueryString", httpCtx.Request.QueryString);

            var endpoint = httpCtx.GetEndpoint();
            if (endpoint != null)
                diagnosticCtx.Set("EndpointName", endpoint.DisplayName);
        }
    }
}
