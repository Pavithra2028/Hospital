using REACTBIGBANG.Models;

namespace REACTBIGBANG.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int patientId);
        Task<Patient> PostPatient(Patient patient);
        Task<int> UpdatePatient(int id, Patient patient);
        Task<int> DeletePatient(int patientId);
    }
}
