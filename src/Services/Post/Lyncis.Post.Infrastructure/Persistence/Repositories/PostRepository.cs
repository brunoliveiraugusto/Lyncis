using Lyncis.Post.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lyncis.Post.Infrastructure.Persistence.Repositories
{
    public class PostRepository(PostDbContext context) : IPostRepository
    {
        private readonly PostDbContext _context = context;

        public async Task<Domain.Entities.Post?> GetByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task AddAsync(Domain.Entities.Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await GetByIdAsync(id);

            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAuthorNameAsync(Guid userId, string newName)
        {
            await _context.Posts
                .Where(p => p.AuthorId == userId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.AuthorName, newName)
                    .SetProperty(p => p.UpdatedAt, DateTime.UtcNow));
        }
    }
}
