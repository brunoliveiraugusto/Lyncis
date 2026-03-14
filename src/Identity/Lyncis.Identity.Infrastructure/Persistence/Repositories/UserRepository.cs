using Lyncis.Identity.Domain.Entities;
using Lyncis.Identity.Domain.Interfaces;

namespace Lyncis.Identity.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserNameAsync(Guid userId, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
