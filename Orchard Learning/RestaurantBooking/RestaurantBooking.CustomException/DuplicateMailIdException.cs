using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.CustomException
{
    public class DuplicateMailIdException : Exception
    {
        public DuplicateMailIdException(string message) : base(message)
        {
        }
    }
}
