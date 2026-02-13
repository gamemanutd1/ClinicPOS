namespace ClinicPOS.Application.Model.Request
{
    public record LoginUserRequest(
        string Username,
        string Password
    );
}
