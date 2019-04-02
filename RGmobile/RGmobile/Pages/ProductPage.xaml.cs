using RGmobile.API_Services;
using RGmobile.Models;
using RGmobile.ViewModels;
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
        public ProductPage (ProductCollection collection)
		{
			InitializeComponent();
            this.BindingContext = new ProductsViewModel(collection);
        }

        private async void Product_Tapped(object sender, EventArgs e)
        {
            if (sender is View view && view.BindingContext is Product product)
            {
                await Navigation.PushAsync(new ProductDetailPage(product));
            }
        }
    }
}