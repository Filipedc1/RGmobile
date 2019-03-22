using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RGmobile.ViewModels
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        private Product _product;
        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(); 
            }
        }

        public string PriceRange => GetProductPriceRange();

        #endregion

        #region Commands

        public ICommand AddToCartCommand { get; private set; }

        #endregion

        #region Constructor

        public ProductDetailViewModel(Product productSelected)
        {
            _product = productSelected;
            AddToCartCommand = new Command(AddToCart);
        }

        #endregion

        #region Methods

        private void AddToCart()
        {
            App.ShoppingCart.Add(_product);
            //Product = null;
        }

        #endregion

        #region Helpers

        private string GetProductPriceRange()
        {
            string range = string.Empty;

            if (Product.CustomerPrices.Any())
            {
                range = $"${Product.CustomerPrices.First().Cost} - ${Product.CustomerPrices.Last().Cost}";
            }
            else if (Product.SalonPrices.Any())
            {
                range = $"${Product.SalonPrices.First()} - ${Product.SalonPrices.Last()}";
            }

            return range;
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
