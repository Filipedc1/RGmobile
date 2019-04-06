using RGmobile.Interfaces;
using RGmobile.Pages;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RGmobile.API_Services
{
    public class NavigationService : IPageNavigation
    {
        public void NavigateToHome(JwtSecurityToken token)
        {
            App.Current.MainPage = new NavigationPage(new HomePage(token));
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
