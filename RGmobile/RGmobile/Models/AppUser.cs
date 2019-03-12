using System;
using System.Collections.Generic;
using System.Text;

namespace RGmobile.Models
{
    public class AppUser
    {
        public string ProfileImageUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Rating { get; set; }

        public DateTime MemberSince { get; set; }
        public Address Address { get; set; }
        public Salon Salon { get; set; }
    }
}
