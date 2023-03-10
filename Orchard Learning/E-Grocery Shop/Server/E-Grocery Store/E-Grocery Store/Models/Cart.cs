using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Models
{
    public class Cart
    {
        [Key]
        public int ItemId { get; set; }
        //This is used id 
        public int CartId { get; set; }
        public int GroceryId { get; set; }
        public virtual Grocery Grocery { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public int Status { get; set; }
    }
}
