using ClinicPOS.Domain.Entity;

namespace ClinicPOS.Infrastructure.Repository
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task<List<Patient>> GetListAsync(string tenantId);
        Task<bool> GetDuplicateByPhoneNo(string tenantId, string phoneNo);
    }
}
