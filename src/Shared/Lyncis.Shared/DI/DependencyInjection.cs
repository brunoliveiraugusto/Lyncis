using Lyncis.Shared.Behaviors;
using Lyncis.Shared.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

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
                        .AddSource("MassTransit")
                        .AddOtlpExporter(options =>
                        {
                            options.Endpoint = new Uri("http://localhost:4317");
                        });
                });

            return services;
        }
    }
}
