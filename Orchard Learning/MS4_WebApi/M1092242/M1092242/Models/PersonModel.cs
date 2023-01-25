using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        [MinLength(3)]
        public string PersonName { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string PersonCity { get; set; }
        [Required]
        public int RoleId { get; set; }

        public RoleModel Role { get; set; }
    }
}
