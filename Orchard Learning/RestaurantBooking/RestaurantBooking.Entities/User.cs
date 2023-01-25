using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantBooking.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [EmailAddress(ErrorMessage = "Enter valid mail id")]
        public string MailId { get; set; }
        public string Password { get; set; }
    }
}
