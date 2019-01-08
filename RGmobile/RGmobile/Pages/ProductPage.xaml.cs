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
	public partial class ProductPage : ContentPage
	{
        public ObservableCollection<Product> Products;

        public ProductPage (ProductCollection collection)
		{
			InitializeComponent();
            Products = new ObservableCollection<Product>();

            foreach (var product in collection.Products)
            {
                Products.Add(product);
            }

            LvProducts.ItemsSource = Products;
        }

        private async void LvProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as Product;

            if (selectedItem != null)
            {
                await Navigation.PushAsync(new ProductDetailPage(selectedItem));
            }

            ((ListView)sender).SelectedItem = null;
        }
    }
}