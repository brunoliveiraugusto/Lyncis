using Lyncis.Identity.Application.Common.Interfaces;
using Lyncis.Identity.Domain.Interfaces;
using Lyncis.Identity.Infrastructure.Messaging;
using Lyncis.Identity.Infrastructure.Persistence;
using Lyncis.Identity.Infrastructure.Persistence.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lyncis.Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.RegisterMassTransit();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IIdentityEventService, IdentityEventService>();

            return services;
        }

        private static IServiceCollection RegisterMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/");
                });
            });

            return services;
        }
    }
}
