using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M1092242.Models
{
    public class ItemModel
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        [MinLength(3)]
        public string ItemName { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string ItemType { get; set; }
        [Required]
        public int FastFoodShopId { get; set; }

        public FastFoodShopModel FastFoodShop { get; set; }
    }
}
