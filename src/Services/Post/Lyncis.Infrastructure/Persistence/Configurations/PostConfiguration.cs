using Lyncis.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lyncis.Infrastructure.Persistence.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
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