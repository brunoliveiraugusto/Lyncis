using Lyncis.Identity.Application.Common.Behaviors;
using Lyncis.Shared.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Lyncis.Identity.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cfg.AddSharedMediatR();
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });

            return services;
        }
    }
}
