using Lyncis.Domain.Entities;
using Lyncis.Domain.Interfaces;

namespace Lyncis.Infrastructure.Persistence.Repositories
{
    public class PostRepository(PostDbContext context) : IPostRepository
    {
        private readonly PostDbContext _context = context;

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
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
    }
}
