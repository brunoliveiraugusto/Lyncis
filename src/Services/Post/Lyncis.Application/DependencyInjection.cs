using Lyncis.Application.Posts.Commands.CreatePost;
using Microsoft.Extensions.DependencyInjection;

namespace Lyncis.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CreatePostCommand).Assembly));

            return services;
        }
    }
}
