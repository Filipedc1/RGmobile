using RGmobile.API_Services;
using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RGmobile.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ProductService _productService;
 
        public ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        //public Command ItemSelectedCommand { get; private set; }

        #region Constructor

        public ProductsViewModel(ProductCollection collection)
        {
            _productService = new ProductService();
            Products = new ObservableCollection<Product>();

            foreach (var product in collection.CollectionProducts)
            {
                Products.Add(product.Product);
            }
        }

        #endregion

        #region Methods


        #endregion
    }
}
