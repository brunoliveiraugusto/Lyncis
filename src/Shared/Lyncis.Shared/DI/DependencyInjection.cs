using Lyncis.Shared.Behaviors;
using Lyncis.Shared.Middlewares;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Enrichers.Span;
using Serilog.Events;
using Serilog.Sinks.Grafana.Loki;

namespace Lyncis.Shared.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }

        public static void AddSharedMediatR(this MediatRServiceConfiguration cfg)
        {
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        }

        public static IServiceCollection AddLyncisTelemetry(this IServiceCollection services, string serviceName)
        {
            services.AddOpenTelemetry()
                .WithTracing(tracing =>
                {
                    tracing
                        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        //Track SQL
                        .AddSource("MassTransit")
                        .AddOtlpExporter(options =>
                        {
                            options.Endpoint = new Uri("http://localhost:4317");
                        });
                });

            return services;
        }

        public static void AddLyncisLogging(this ILoggingBuilder logging, IConfiguration configuration, string serviceName)
        {
            var logger = new LoggerConfiguration()
                .Enrich.WithProperty("Application", serviceName)
                .Enrich.FromLogContext()
                .Enrich.WithSpan()
                .WriteTo.Console()
                .WriteTo.GrafanaLoki("http://localhost:3100",
                [
                    new LokiLabel { Key = "Application", Value = serviceName }
                ])
                .MinimumLevel.Override("MassTransit", LogEventLevel.Information)
                .CreateLogger();

            logging.ClearProviders();
            logging.AddSerilog(logger);
        }
    }
}
