using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.Entities
{
    public class BookingDetail
    {
        public int BookingId { get; set; }
        public string RestaurantName { get; set; }
        public int NoOfPeople { get; set; }
        public string MealType { get; set; }
        public DateTime BookiingDate { get; set; }
    }
}
