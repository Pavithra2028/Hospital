using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REACTBIGBANG.Models;
using REACTBIGBANG.Repository;

namespace REACTBIGBANG.Controllers
{
    //[Authorize(Roles = "Patients")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            try
            {
                var patients = await _patientRepository.GetAllPatients();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving patients: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving patient: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            var createdPatient = await _patientRepository.PostPatient(patient);

            if (createdPatient == null)
            {
                return Problem("Failed to create patient.");
            }

            //return CreatedAtAction("GetPatient", new { id = createdPatient.patient_id }, createdPatient);
            //return CreatedAtAction("Get", new { id = createdCourse.doctor_id }, createdCourse);
            return Created("Get", createdPatient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdatePatient(int id, Patient patient)
        {
            try
            {
                if (id != patient.Patient_id)
                {
                    return BadRequest("Invalid patient ID.");
                }

                var result = await _patientRepository.UpdatePatient(id, patient);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating patient: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeletePatient(int id)
        {
            try
            {
                var result = await _patientRepository.DeletePatient(id);
                if (result == 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting patient: {ex.Message}");
            }
        }
    }
}
