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
    public class ProductsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product> Products;
        private ProductService _productService;

        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

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


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
