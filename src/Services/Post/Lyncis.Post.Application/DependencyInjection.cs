using Lyncis.Shared.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Lyncis.Post.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                cfg.AddSharedMediatR();
            });

            return services;
        }
    }
}
