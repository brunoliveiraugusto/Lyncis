using Lyncis.Identity.Domain.Entities;

namespace Lyncis.Identity.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task UpdateUserNameAsync(Guid userId, string newName);
    }
}
