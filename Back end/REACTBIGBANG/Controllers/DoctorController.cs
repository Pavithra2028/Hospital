using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REACTBIGBANG.Models;
using REACTBIGBANG.Repository;
using System.Data;

namespace REACTBIGBANG.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository doc;

        public DoctorController(IDoctorRepository doc)
        {
            this.doc = doc;
        }

        [HttpGet]
        public ICollection<Doctor>? Get()
        {

            return doc.GetDoctor();
        }

        [HttpGet("{Doctor_id}")]
        public Doctor? DoctorbyId(int Doctor_id)
        {

         return doc.DoctorById(Doctor_id);
        }
        [HttpPost]
        public async Task<ActionResult<Doctor>> Post([FromForm] Doctor doctor, IFormFile imageFile)
        {

            try
            {
                var createdCourse = await doc.CreateDoctor(doctor, imageFile);
                return CreatedAtAction("Get", new { id = createdCourse.Doctor_id }, createdCourse);

            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{Doctor_id}")]
        public async Task<ActionResult<Doctor>> Put(int Doctor_id, [FromForm] Doctor doctor, IFormFile imageFile)
        {
            try
            {
                var updatedCake = await doc.UpdateDoctor(Doctor_id, doctor, imageFile);
                if (updatedCake == null)
                {
                    return NotFound();
                }

                return Ok(updatedCake);
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return BadRequest(ModelState);
            }
        }


        [HttpDelete("{Doctor_id}")]
        public Doctor? DeleteDoctor(int Doctor_id)
        {
            return doc.DeleteDoctor(Doctor_id);
        }

      

    }
}
