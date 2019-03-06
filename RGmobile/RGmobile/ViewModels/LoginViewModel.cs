using RGmobile.API_Services;
using RGmobile.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RGmobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AccountService _accountService;


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

        private string username;
        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute(); //re-evaluates the command whenever isBusy is changed
            }
        }

        public Command LoginCommand { get; private set; }

        #region Constructor

        public LoginViewModel()
        {
            _accountService = new AccountService();
            LoginCommand = new Command<LoginViewModel>(async (model) => await LoginAsync(model), 
                                                             (model) => !IsBusy);
        }

        #endregion

        #region Methods

        private async Task LoginAsync(LoginViewModel model)
        {
            IsBusy = true;

            string token = await _accountService.Login(model);

            if (string.IsNullOrEmpty(token))
            {
                IsBusy = false;
                await App.Current.MainPage.DisplayAlert("Error", "Invalid credentials", "Ok");
                return;
            }

            IsBusy = false;
            await App.Current.MainPage.Navigation.PushAsync(new HomePage());
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
