using Microsoft.AspNetCore.Mvc;
using REACTBIGBANG.Models;

namespace REACTBIGBANG.Repository
{
    public interface IDoctorRepository
    {
        public ICollection<Doctor> GetDoctor();

        public Doctor DoctorById(int Doctor_id);

        Task<Doctor> CreateDoctor([FromForm] Doctor doctor, IFormFile imageFile);

        Task<Doctor> UpdateDoctor(int doctorid, Doctor doctor, IFormFile imageFile);


        public Doctor DeleteDoctor(int doctorid);
    }
}
