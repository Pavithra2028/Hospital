using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using REACTBIGBANG.Models;

namespace REACTBIGBANG.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly HospitalContext _dbContext;

        public PatientRepository(HospitalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            try
            {
                return await _dbContext.patients.Include(x => x.Doctors).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve patients.", ex);
            }
        }

        public async Task<Patient> GetPatientById(int Patient_id)
        {
            try
            {
                return await _dbContext.patients.FirstOrDefaultAsync(p => p.Patient_id == Patient_id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to retrieve the patient by ID.", ex);
            }
        }

        public async Task<Patient> PostPatient(Patient patient)
        {
            try
            {
                if (_dbContext.patients == null)
                {
                    throw new NullReferenceException("Entity set 'HospitalContext.patients' is null.");
                }

                _dbContext.patients.Add(patient);
                await _dbContext.SaveChangesAsync();

                return patient;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> UpdatePatient(int id, Patient patient)
        {
            try
            {

                _dbContext.Entry(patient).State = EntityState.Modified;
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update the patient.", ex);
            }
        }

        public async Task<int> DeletePatient(int patientId)
        {
            try
            {
                var patient = await _dbContext.patients.FindAsync(patientId);
                if (patient != null)
                {
                    _dbContext.patients.Remove(patient);
                    return await _dbContext.SaveChangesAsync();
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete the patient.", ex);
            }
        }
    }
}
