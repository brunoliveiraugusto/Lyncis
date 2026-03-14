using Lyncis.Identity.Domain.Entities;
using Lyncis.Identity.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lyncis.Identity.Infrastructure.Persistence.Repositories
{
    public class UserRepository(IdentityDbContext context) : IUserRepository
    {
        private readonly IdentityDbContext _context = context;

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public Task UpdateUserNameAsync(Guid userId, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
