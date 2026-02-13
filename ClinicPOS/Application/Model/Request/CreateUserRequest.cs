namespace ClinicPOS.Application.Model.Request
{
    public record CreateUserRequest(
        string Username,
        string Password,
        string FirstName,
        string LastName,
        string TelNo,
        string IDCardNo
    );
}
