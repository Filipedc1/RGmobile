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
    public class ProductCollectionsViewModel : BaseViewModel
    {
        private ProductService _productService;

        public Command LoadProductCollectionsCommand { get; private set; }
        public Command GoToShoppingCartCommand { get; private set; }


        public ObservableCollection<ProductCollection> _productCollections;
        public ObservableCollection<ProductCollection> ProductCollections
        {
            get => _productCollections;
            set
            {
                _productCollections = value;
                OnPropertyChanged();
            }
        }

        #region Constructor

        public ProductCollectionsViewModel()
        {
            _productService = new ProductService();
            ProductCollections = new ObservableCollection<ProductCollection>();

            LoadProductCollectionsCommand = new Command(async () => await LoadProductCollections());
            GoToShoppingCartCommand = new Command(async () => await GoToShoppingCartPage());
        }

        #endregion

        #region Methods

        private async Task LoadProductCollections()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var collections = await _productService.GetProductCollections();

                if (collections != null && collections.Count > 0)
                {
                    foreach (var collection in collections)
                    {
                        ProductCollections.Add(collection);
                    }
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GoToShoppingCartPage()
        {
            if (IsBusy) return;

            await _navigationService.NavigateToShoppingCart();
        }

        #endregion
    }
}
