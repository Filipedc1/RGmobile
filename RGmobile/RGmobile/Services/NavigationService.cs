using RGmobile.Interfaces;
using RGmobile.Pages;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.API_Services
{
    public class NavigationService : IPageNavigation
    {
        public async Task NavigateToHome(JwtSecurityToken token)
        {
            await App.Current.MainPage.Navigation.PushAsync(new HomePage(token));
        }

        //public async Task NavigateToLogin()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task NavigateToRegister()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
