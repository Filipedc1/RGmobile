using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.Interfaces
{
    public interface IPageNavigation
    {
        //Task NavigateToLogin();
        //Task NavigateToRegister();
        void NavigateToHome(JwtSecurityToken token);
    }
}
