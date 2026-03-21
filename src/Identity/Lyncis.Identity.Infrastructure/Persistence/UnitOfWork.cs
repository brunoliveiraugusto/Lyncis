using Lyncis.Identity.Application.Common.Interfaces;

namespace Lyncis.Identity.Infrastructure.Persistence
{
    public class UnitOfWork(IdentityDbContext dbContext) : IUnitOfWork
    {
        private readonly IdentityDbContext _dbContext = dbContext;

        public async Task<int> SaveChangesAsync(CancellationToken ct) =>
            await _dbContext.SaveChangesAsync(ct);

        public async Task BeginTransactionAsync(CancellationToken ct) =>
            await _dbContext.Database.BeginTransactionAsync(ct);

        public async Task CommitTransactionAsync(CancellationToken ct) =>
            await _dbContext.Database.CommitTransactionAsync(ct);

        public async Task RollbackTransactionAsync(CancellationToken ct) =>
            await _dbContext.Database.RollbackTransactionAsync(ct);
    }
}
