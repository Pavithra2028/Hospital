using Microsoft.EntityFrameworkCore;

namespace REACTBIGBANG.Models
{
    public class HospitalContext:DbContext
    {
        public DbSet<Doctor> doctors { get; set; }

        public DbSet<Patient> patients { get; set; }

        public DbSet<Admin> admins { get; set; }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

    }
}
