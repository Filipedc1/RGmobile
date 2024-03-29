﻿using RGmobile.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RGmobile.Models
{
    public class Product
    {
        public int ProductId        { get; set; }
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string ImageUrl      { get; set; }

        public string PriceRange => ProductUtils.GetProductPriceRange(this);

        public virtual IEnumerable<CustomerPrice> CustomerPrices { get; set; }
        public virtual IEnumerable<SalonPrice> SalonPrices { get; set; }

        public ICollection<CollectionProduct> CollectionProducts { get; set; }
    }
}
