namespace ClinicPOS.Application.Model.Request
{
    public record CreatePatientRequest(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string TenantId
    );
}
