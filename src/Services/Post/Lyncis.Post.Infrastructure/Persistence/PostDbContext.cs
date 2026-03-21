using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Lyncis.Post.Infrastructure.Persistence
{
    public class PostDbContext(DbContextOptions<PostDbContext> options) : DbContext(options)
    {
        public DbSet<Domain.Entities.Post> Posts => Set<Domain.Entities.Post>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostDbContext).Assembly);
            modelBuilder.AddTransactionalOutboxEntities();
        }
    }
}
