namespace ClinicPOS.Application.Model.Response
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IDCardNo { get; set; }
        public string? TelNo { get; set; }
    }
}
