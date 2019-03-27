using RGmobile.Models;
using RGmobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RGmobile.Helpers
{
    public static class ShoppingCartHelper
    {
        public static bool IsAlreadyInCart(Product product, string selectedSize)
        {
            bool isDuplicate = App.ShoppingCart.Any(p => p.ProductId == product.ProductId && p.Size == selectedSize);

            return isDuplicate ? true : false;
        }

        public static void AddToCart(ProductViewModel product) => App.ShoppingCart.Add(product);

        public static void UpdateItemQuantity(int productId, string selectedSize, int quantity)
        {
            var prod = App.ShoppingCart.FirstOrDefault(p => p.ProductId == productId && p.Size == selectedSize);
            prod.Quantity += quantity;
        }
    }
}
