using ClinicPOS.Application.Model.Response;
using ClinicPOS.Application.Model.Request;

namespace ClinicPOS.Domain.Service
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetListAsync(string tenantId, string branchId);
        Task<bool> GetDuplicateByPhoneNo(string tenantId, string phoneNo);
        Task CreatePatientAsync(CreatePatientRequest request);
    }
}
