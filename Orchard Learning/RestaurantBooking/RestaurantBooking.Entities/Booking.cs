using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.Entities
{
    public class Booking
    {
        public int RestaurantId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int NoOfPeople { get; set; }
        public string MealType { get; set; }
        public DateTime BookiingDate { get; set; }
    }
}
