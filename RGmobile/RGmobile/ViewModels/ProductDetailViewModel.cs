using RGmobile.Helpers;
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

        private CustomerPrice _selectedSize;
        public CustomerPrice SelectedSize
        {
            get { return _selectedSize; }
            set
            {
                _selectedSize = value;
                OnPropertyChanged();

                Cost = $"${_selectedSize.Cost.ToString()}";
            }
        }

        public string _cost;
        public string Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged();
            }
        }

        public string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

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
            int quantity = int.Parse(Quantity);

            // If true, update quantity on the item already in the cart
            if (ShoppingCartHelper.IsAlreadyInCart(Product, SelectedSize.Size))
            {
                ShoppingCartHelper.UpdateItemQuantity(Product.ProductId, SelectedSize.Size, quantity);
                return;
            }

            var productVM = new ProductViewModel
            {
                ProductId = Product.ProductId,
                Name = Product.Name,
                Description = Product.Description,
                ImageUrl = Product.ImageUrl,
                Quantity = quantity,
                Size = SelectedSize.Size,
                Cost = SelectedSize.Cost * quantity
            };

            ShoppingCartHelper.AddToCart(productVM);
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
