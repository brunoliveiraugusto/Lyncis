using Lyncis.Domain.Entities;
using Lyncis.Domain.Interfaces;

namespace Lyncis.Infrastructure.Persistence
{
    public class PostRepository : IPostRepository
    {
        private readonly Dictionary<Guid, Post> _posts = [];

        public Task<Post?> GetByIdAsync(Guid id)
        {
            _posts.TryGetValue(id, out var post);
            return Task.FromResult(post);
        }

        public Task AddAsync(Post post)
        {
            _posts[post.Id] = post;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Post post)
        {
            _posts[post.Id] = post;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _posts.Remove(id);
            return Task.CompletedTask;
        }
    }
}
