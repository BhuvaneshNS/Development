using System;

namespace LibraryManagement.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public byte Active { get; set; }
    }
}

