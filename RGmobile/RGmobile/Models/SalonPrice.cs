using System;
using System.Collections.Generic;
using System.Text;

namespace RGmobile.Models
{
    public class SalonPrice
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public decimal Cost { get; set; }

        public virtual Product Product { get; set; }
    }
}
