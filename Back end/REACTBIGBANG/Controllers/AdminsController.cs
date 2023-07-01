using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REACTBIGBANG.Models;

namespace REACTBIGBANG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly HospitalContext _context;

        public AdminsController(HospitalContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> Getadmins()
        {
          if (_context.admins == null)
          {
              return NotFound();
          }
            return await _context.admins.ToListAsync();
        }

      
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
          if (_context.admins == null)
          {
              return Problem("Entity set 'HospitalContext.admins'  is null.");
          }
            _context.admins.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.Admin_id }, admin);
        }


        private bool AdminExists(int id)
        {
            return (_context.admins?.Any(e => e.Admin_id == id)).GetValueOrDefault();
        }
    }
}
