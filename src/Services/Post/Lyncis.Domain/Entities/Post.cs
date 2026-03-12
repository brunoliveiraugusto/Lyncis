using Lyncis.Domain.Entities.Enums;

namespace Lyncis.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public string AuthorName { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public PostStatus Status { get; private set; }
        public IReadOnlyCollection<Guid> MediaIds => _mediaIds.AsReadOnly();

        private readonly List<Guid> _mediaIds = [];

        internal Post(Guid authorId, string authorName, string content)
        {
            ValidateAuthor(authorId, authorName);
            ValidateContent(content);

            Id = Guid.NewGuid();
            AuthorId = authorId;
            AuthorName = authorName;
            Content = content;
            CreatedAt = DateTime.UtcNow;
            Status = PostStatus.Published;
        }

        public void UpdateContent(string newContent)
        {
            ValidateContent(newContent);
            Content = newContent;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AttachMedia(Guid mediaId)
        {
            if (_mediaIds.Count >= 4)
                throw new InvalidOperationException("A post can have a maximum of 4 media items.");

            _mediaIds.Add(mediaId);
        }

        private static void ValidateAuthor(Guid authorId, string authorName)
        {
            if (Guid.Empty == authorId)
                throw new ArgumentException("Post author id cannot be empty.");

            if (string.IsNullOrEmpty(authorName))
                throw new ArgumentException("Post author name cannot be empty.");
        }

        private static void ValidateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty.");

            if (content.Length > 280)
                throw new ArgumentException("Post content exceeds the 280 character limit.");
        }
    }
}
