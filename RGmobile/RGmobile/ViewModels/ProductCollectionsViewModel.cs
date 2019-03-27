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
    public class ProductCollectionsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ProductCollection> ProductCollections;
        private ProductService _productService;

        public Command LoadProductCollectionsCommand { get; private set; }

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

        public ProductCollectionsViewModel()
        {
            _productService = new ProductService();
            ProductCollections = new ObservableCollection<ProductCollection>();

            LoadProductCollectionsCommand = new Command(async () => await LoadProductCollections());
        }

        #endregion

        #region Methods

        private async Task LoadProductCollections()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

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

        #endregion


        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
