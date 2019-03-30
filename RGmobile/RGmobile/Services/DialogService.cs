using RGmobile.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.Services
{
    public class DialogService : IDialog
    {
        public async Task ShowDialog(string title, string message, string cancel)
        {
            await App.Current.MainPage.DisplayAlert("Login Failure", "Invalid credentials", "Ok");
        }

        public async Task ShowDialog(string title, string message, string accept, string cancel)
        {
            await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
