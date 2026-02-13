using ClinicPOS.Application.Model.Request;
using ClinicPOS.Application.Model.Response;
using ClinicPOS.Domain.Entity;
using ClinicPOS.Infrastructure.Repository;

namespace ClinicPOS.Domain.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<PatientDto>> GetListAsync(string tenantId, string branchId)
        {
            var returnDto = new List<PatientDto>();
            var query = await _patientRepository.GetListAsync(tenantId);
            
            if (string.IsNullOrEmpty(branchId))
                query = query.Where(p => p.PrimaryBranchId == new Guid(branchId)).ToList();

            foreach (var q in query)
            {
                returnDto.Add(new PatientDto
                {
                    FirstName = q.FirstName,
                    LastName = q.LastName,
                    PhoneNumber = q.PhoneNumber
                });
            }

            return returnDto;
        }

        public async Task<bool> GetDuplicateByPhoneNo(string tenantId, string phoneNo)
            => await _patientRepository.GetDuplicateByPhoneNo(tenantId, phoneNo);

        public async Task CreatePatientAsync(CreatePatientRequest request)
        {
            var patient = new Patient {
                Id = new Guid(),
                TenantId = new Guid(request.TenantId),
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };

            await _patientRepository.AddAsync(patient);
        }
    }
}
