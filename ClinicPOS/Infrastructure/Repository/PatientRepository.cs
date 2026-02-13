using Azure.Core;
using ClinicPOS.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClinicPOS.Infrastructure.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Patient>> GetListAsync(string tenantId) 
            => _context.Patients.Where(p => p.TenantId == new Guid(tenantId)).ToListAsync();

        public async Task<bool> GetDuplicateByPhoneNo(string tenantId, string phoneNo)
        {
            return await _context.Patients
                .AnyAsync(p => p.TenantId == new Guid(tenantId) && p.PhoneNumber == phoneNo);
        }

        public async Task AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }
    }
}
