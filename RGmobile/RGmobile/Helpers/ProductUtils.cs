using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RGmobile.Helpers
{
    public static class ProductUtils
    {
        public static string GetProductPriceRange(Product product)
        {
            string range = string.Empty;

            if (App.UserRole == RoleType.Customer && product.CustomerPrices != null && product.CustomerPrices.Count() > 0)
            {
                range = $"${product.CustomerPrices.FirstOrDefault().Cost} - ${product.CustomerPrices.LastOrDefault().Cost}";
            }
            else if (App.UserRole == RoleType.Salon && product.SalonPrices != null && product.SalonPrices.Count() > 0)
            {
                range = $"${product.SalonPrices.FirstOrDefault()} - ${product.SalonPrices.LastOrDefault()}";
            }

            return range ?? "N/A";
        }
    }
}
