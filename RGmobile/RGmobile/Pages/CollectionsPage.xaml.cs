using RGmobile.API_Services;
using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RGmobile.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CollectionsPage : ContentPage
	{
        public ObservableCollection<ProductCollection> ProductCollections;
        private ProductService _productService;

        //using this to prevent api to get called everytime you click Menus tab
        public static bool first = true;

        public CollectionsPage ()
		{
			InitializeComponent();
            ProductCollections = new ObservableCollection<ProductCollection>();
            _productService = new ProductService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (first)
                {
                    var collections = await _productService.GetProductCollections();

                    foreach (var collection in collections)
                    {
                        ProductCollections.Add(collection);
                    }

                    LvCollection.ItemsSource = ProductCollections;
                }

                first = false;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                BusyIndicator.IsRunning = false;
            }
        }

        private async void LvCollection_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as ProductCollection;

            if (selectedItem != null)
                await Navigation.PushAsync(new ProductPage(selectedItem));

            ((ListView)sender).SelectedItem = null;
        }
    }
}