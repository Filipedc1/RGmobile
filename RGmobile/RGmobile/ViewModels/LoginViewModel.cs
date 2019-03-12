using RGmobile.API_Services;
using RGmobile.Helpers;
using RGmobile.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private UserService _userService;


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
            _userService = new UserService();
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
                await App.Current.MainPage.DisplayAlert("Login Failure", "Invalid credentials", "Ok");
                return;
            }

            //await FinishLogin(token, model.UserName);

            IsBusy = false;

            await App.Current.MainPage.Navigation.PushAsync(new HomePage(token));
        }

        //Need to finish this later. Keep simple login for now and just build out the app.
        public async Task FinishLogin(string access_token, string username)
        {
            Settings.AccessToken = access_token;

            var decodedToken = new JwtSecurityToken(access_token);
            var claims = decodedToken.Claims.ToList();

            string expires = claims.FirstOrDefault(x => x.Type == "exp").Value;

            long.TryParse(expires, out long time);
            long nextTime = DateTime.Now.AddSeconds(time).Ticks;
            Settings.KeyValidUntil = nextTime;

            //try
            //{
            //    var user = await _userService.GetUserByUsername(username);
            //    Settings.UserId = user.Id.ToString();
            //    Settings.UserName = user.Name ?? string.Empty;
            //}
            //catch (Exception ex)
            //{

            //}

            //IsBusy = false;

            //await App.Current.MainPage.Navigation.PushAsync(new HomePage(token));
        }

        #endregion

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
