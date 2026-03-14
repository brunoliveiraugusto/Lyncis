namespace Lyncis.Post.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<Entities.Post?> GetByIdAsync(Guid id);
        Task AddAsync(Entities.Post post);
        Task UpdateAsync(Entities.Post post);
        Task DeleteAsync(Guid id);
        Task UpdateAuthorNameAsync(Guid userId, string newName);
    }
}
