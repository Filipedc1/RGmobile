using System;
using System.Collections.Generic;
using System.Text;

namespace RGmobile.Models
{
    public class CollectionProduct
    {
        public int ProductCollectionId { get; set; }
        public ProductCollection ProductCollection { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
