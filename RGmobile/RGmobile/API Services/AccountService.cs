using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.API_Services
{
    public class AccountService
    {
        //Get Request
        public async Task<string> Login()
        {
            var client = new HttpClient();

            //send request to server. Server will send response back in JSON format
            var response = await client.GetStringAsync("https://localhost:44308/api/User/login");
            return JsonConvert.DeserializeObject<string>(response);
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
