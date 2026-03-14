using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lyncis.Post.Infrastructure.Persistence.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Domain.Entities.Post>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Post> entity)
        {
            entity.ToTable("Posts");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.AuthorName)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(280);

            entity.Property(p => p.MediaIds)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                          .Select(Guid.Parse)
                          .ToList()
                );
        }
    }
}