using System.ComponentModel.DataAnnotations;

namespace REACTBIGBANG.Models
{
    public class Doctor
    {
        [Key]

       public int Doctor_id { get; set; }

       public string? Doctor_name { get; set; }

       public string? Doctor_image { get; set; }

       public string? Specialization { get; set; }

       public string? Doctor_gender { get; set; }

       public int Doctor_experience { get; set; }

       public string? Doctor_password { get; set; }

       public string? Status { get; set; }

        public ICollection<Patient>? patients { get; set; }
    }
}
