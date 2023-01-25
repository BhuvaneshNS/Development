using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Models
{
    public class FastFoodShopModel
    {
        [Key]
        public int FastFoodShopId { get; set; }
        [Required]
        [MinLength(3)]
        public string FastFoodShopName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
