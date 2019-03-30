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
	public partial class CollectionsPage : ContentPage
	{
        //using this to prevent api to get called everytime you click Menus tab
        public static bool first = true;

        ProductCollectionsViewModel VM { get; set; }

        public CollectionsPage ()
		{
			InitializeComponent();
            this.VM = new ProductCollectionsViewModel();
            this.BindingContext = this.VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (first)
                this.VM.LoadProductCollectionsCommand.Execute(null);

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