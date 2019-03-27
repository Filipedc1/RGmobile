using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RGmobile.Models;
using RGmobile.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.API_Services
{
    public class AccountService
    {
        private HttpClient _client;

        public AccountService()
        {
            _client = new HttpClient();
        }

        //Post Request
        public async Task<JwtSecurityToken> Login(LoginViewModel model)
        {
            //send data to server in JSON format
            string json = JsonConvert.SerializeObject(model);

            try
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await _client.PostAsync("https://rg-api.azurewebsites.net/api/User/login", content);

                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();

                    new JwtSecurityTokenHandler().ValidateToken(response, GetValidationParameters(), out SecurityToken validatedToken);

                    return validatedToken as JwtSecurityToken;
                }
            }
            catch (Exception e)
            {
                return null;
            }
            
            return null;
        }

        //Post Request
        //public async Task<bool> ReserveTable(Reservation reservation)
        //{
        //    var client = new HttpClient();

        //    //send data to server in JSON format
        //    string json = JsonConvert.SerializeObject(reservation);

        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    var response = await client.PostAsync("https://expresso-api.azurewebsites.net/api/Reservations", content);

        //    return response.IsSuccessStatusCode;
        //}

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, 
                ValidateAudience = true, 
                ValidateIssuer = true,  
                ValidIssuer = "http://localhost:5000",
                ValidAudience = "http://localhost:5000",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SomeRandomKeyGenerated")) 
            };
        }
    }
}
