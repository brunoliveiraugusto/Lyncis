using Lyncis.Domain.Interfaces;
using Lyncis.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Lyncis.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IPostRepository, PostRepository>();

            return services;
        }
    }
}
