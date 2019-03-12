using Newtonsoft.Json;
using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.API_Services
{
    public class UserService
    {
        private HttpClient _client;
        private const string GetUserUrl = @"https://rg-api.azurewebsites.net/api/User/login";

        public UserService()
        {
            _client = new HttpClient();
        }

        //Post Request
        public async Task<string> GetUserByUsername(string username)
        {
            var response = await _client.GetAsync("https://rg-api.azurewebsites.net/api/User/login");

            if (response.IsSuccessStatusCode)
            {
                var responseValue = await response.Content.ReadAsStringAsync();
                return responseValue;
            }

            return null;
        }
    }
}
