namespace Lyncis.Identity.Contracts
{
    /// <summary>
    /// Published when a user changes their profile information.
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="NewName"></param>
    /// <param name="UpdatedAt"></param>
    public record UserRenamedEvent(Guid UserId, string NewName, DateTime UpdatedAt);
}
