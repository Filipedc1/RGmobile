using System;
using System.Collections.Generic;
using System.Text;

namespace RGmobile.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId        { get; set; }
        public string Name          { get; set; }
        public string Description   { get; set; }
        public string ImageUrl      { get; set; }
        public decimal Cost         { get; set; }
        public int Quantity         { get; set; }
        public string Size          { get; set; }

        public string CostString => $"${Cost}";
    }
}
