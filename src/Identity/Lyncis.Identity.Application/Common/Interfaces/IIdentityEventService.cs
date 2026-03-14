namespace Lyncis.Identity.Application.Common.Interfaces
{
    public interface IIdentityEventService
    {
        Task PublishUserRenamedAsync(Guid userId, string newName, CancellationToken ct = default);
    }
}
