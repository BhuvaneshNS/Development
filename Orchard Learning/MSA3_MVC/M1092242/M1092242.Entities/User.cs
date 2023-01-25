using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M1092242.Entities
{
    public class User
    {
        public int ID { get; set; }
        public int ServiceCenterId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Adress { get; set; }
        public DateTime AppointmentBookingDate { get; set; }
        public string LaptopMake { get; set; }
        public string LaptopModel { get; set; }
    }
}
