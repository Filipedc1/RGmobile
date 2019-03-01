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
        private ProductCollectionService productCollectionService;

        //using this to prevent api to get called everytime you click Menus tab
        public static bool first = true;

        public CollectionsPage ()
		{
			InitializeComponent();
            ProductCollections = new ObservableCollection<ProductCollection>();
            productCollectionService = new ProductCollectionService();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (first)
            {
                //var collections = await productCollectionService.GetProductCollections();

                //foreach (var collection in collections)
                //{
                //    ProductCollections.Add(collection);
                //}

                LvCollection.ItemsSource = ProductCollections;
                BusyIndicator.IsRunning = false;
            }

            first = false;
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
