using Lyncis.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lyncis.Infrastructure.Persistence
{
    public class PostDbContext(DbContextOptions<PostDbContext> options) : DbContext(options)
    {
        public DbSet<Post> Posts => Set<Post>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostDbContext).Assembly);
        }
    }
}
