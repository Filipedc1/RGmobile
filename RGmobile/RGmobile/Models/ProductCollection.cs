using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RGmobile.Models
{
    public class ProductCollection
    {
        public int Id                   { get; set; }
        public string Name              { get; set; }
        public string Image             { get; set; }
        public List<Product> Products   { get; set; }
    }
}
