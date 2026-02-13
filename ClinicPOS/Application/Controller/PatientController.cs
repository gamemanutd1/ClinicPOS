using ClinicPOS.Application.Model.Response;
using ClinicPOS.Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace ClinicPOS.Application.Model.Request
{
    [ApiController]
    [Route("api/patient")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PatientDto>>> List([FromQuery] string tenantId, [FromQuery] string branchId)
            => Ok(await _patientService.GetListAsync(tenantId, branchId));

        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientRequest request)
        {
            bool exists = await _patientService.GetDuplicateByPhoneNo(request.TenantId, request.PhoneNumber);
            if (exists) return BadRequest("A patient with this phone number already exists in your clinic.");

            await _patientService.CreatePatientAsync(request);
            return Ok();
        }
    }
}
