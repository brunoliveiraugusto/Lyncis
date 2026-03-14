namespace Lyncis.Post.Domain.Factories
{
    public static class PostFactory
    {
        public static Entities.Post Create(Guid authorId, string authorName, string content, List<Guid>? mediaIds)
        {
            var post = new Entities.Post(authorId, authorName, content);

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
