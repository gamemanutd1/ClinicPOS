namespace ClinicPOS.Domain.Authorization
{
    public interface ICurrentUser
    {
        Guid UserId { get; }
        string? Role { get; }
    }

}
