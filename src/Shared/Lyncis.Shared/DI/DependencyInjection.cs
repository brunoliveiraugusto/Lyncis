using Lyncis.Shared.Behaviors;
using Lyncis.Shared.Middlewares;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
