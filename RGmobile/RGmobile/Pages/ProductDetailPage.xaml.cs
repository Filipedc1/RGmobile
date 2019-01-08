using RGmobile.Models;
using RGmobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RGmobile.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailPage : ContentPage
	{
		public ProductDetailPage (Product product)
		{
			InitializeComponent ();
            BindingContext = new ProductDetailViewModel(product);
        }
	}
}