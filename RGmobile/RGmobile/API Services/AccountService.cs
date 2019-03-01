using Newtonsoft.Json;
using RGmobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.API_Services
{
    public class AccountService
    {
        //Post Request
        public async Task<string> Login(LoginViewModel model)
        {
            var client = new HttpClient();

            //send data to server in JSON format
            string json = JsonConvert.SerializeObject(model);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://rg-api.azurewebsites.net/api/User/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseValue = await response.Content.ReadAsStringAsync();
                return responseValue;
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


    }
}
