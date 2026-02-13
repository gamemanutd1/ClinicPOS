namespace ClinicPOS.Application.Model.Request
{
    public record UpdateUserRequest(
        string Username,
        string FirstName,
        string LastName,
        string TelNo,
        bool IsActive
    );
}
