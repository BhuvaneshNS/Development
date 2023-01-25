using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Grocery_Store.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
    }
}
