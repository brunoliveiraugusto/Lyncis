using Lyncis.Domain.Entities;

namespace Lyncis.Domain.Factories
{
    public static class PostFactory
    {
        public static Post Create(Guid authorId, string content, List<Guid>? mediaIds)
        {
            var post = new Post(authorId, content);

            if (mediaIds != null)
            {
                foreach (var mediaId in mediaIds)
                {
                    post.AttachMedia(mediaId);
                }
            }

            return post;
        }
    }
}
