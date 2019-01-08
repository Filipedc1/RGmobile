using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RGmobile.ViewModels
{
    public class ProductDetailViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        public ICommand AddToCartCommand { get; private set; }

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
            Product = null;
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
