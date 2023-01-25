using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Models
{

    // This model is used to bing email and password provided during login
    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        [NotMapped]
        public string EmailId { get; set; }
        [Required]
        [NotMapped]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
