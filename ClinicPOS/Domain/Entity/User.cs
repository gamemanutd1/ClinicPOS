
namespace ClinicPOS.Domain.Entity
{
    public class User : BaseEntity
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required Guid RoleId { get; set; }
        public required bool IsActive { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
