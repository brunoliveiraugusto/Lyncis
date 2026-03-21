using Lyncis.Post.Domain.Interfaces;
using Lyncis.Post.Infrastructure.Messaging;
using Lyncis.Post.Infrastructure.Persistence;
using Lyncis.Post.Infrastructure.Persistence.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lyncis.Post.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.RegisterMessageBroker(configuration);

            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }

        private static IServiceCollection RegisterMessageBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(mt =>
            {
                mt.AddEntityFrameworkOutbox<PostDbContext>(o =>
                {
                    o.UseSqlServer();
                });

                mt.AddConsumer<UserRenamedConsumer>();

                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"] ?? "localhost", "/");

                    cfg.ReceiveEndpoint(queueName: configuration["RabbitMQ:UserRenamedEvent"] ?? throw new ArgumentException("Queue name not defined"), e =>
                    {
                        e.UseEntityFrameworkOutbox<PostDbContext>(context);

                        e.ConfigureConsumer<UserRenamedConsumer>(context);
                    });
                });
            });

            return services;
        }
    }
}
