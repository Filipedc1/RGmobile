using RGmobile.API_Services;
using RGmobile.Models;
using RGmobile.Pages;
using RGmobile.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RGmobile
{
    public partial class App : Application
    {
        public static List<ProductViewModel> ShoppingCart { get; set; } = new List<ProductViewModel>();
        public static RoleType? UserRole { get; set; } //temporary

        public App()
        {
            InitializeComponent();
            RegisterServices();

            MainPage = new NavigationPage(new LoginPage());
        }

        private void RegisterServices()
        {
            DependencyService.Register<NavigationService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
