using System.ComponentModel.DataAnnotations;

namespace REACTBIGBANG.Models
{
    public class Admin
    {
        [Key]

        public int Admin_id { get; set; }

        public string Admin_name { get; set; }

        public string Admin_password { get; set; }

    }
}
