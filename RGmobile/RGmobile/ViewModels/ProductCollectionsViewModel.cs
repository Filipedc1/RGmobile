using RGmobile.API_Services;
using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace RGmobile.ViewModels
{
    public class ProductCollectionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProductCollection> ProductCollections;
        private ProductService _productService;

        #region Constructor

        public ProductCollectionsViewModel()
        {
            _productService = new ProductService();
            ProductCollections = new ObservableCollection<ProductCollection>();
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
