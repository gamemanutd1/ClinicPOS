namespace ClinicPOS.Domain.Entity
{
    public class Patient : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid PrimaryBranchId { get; set; }
    }
}
