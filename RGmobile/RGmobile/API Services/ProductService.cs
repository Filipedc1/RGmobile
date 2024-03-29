﻿using Newtonsoft.Json;
using RGmobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.API_Services
{
    public class ProductService
    { 
        private const string GetProductCollectionsForCustomersUrl = @"https://rg-api.azurewebsites.net/api/Product/getproductcollectionscustomer";
        private const string GetProductCollectionsForSalonsUrl = @"https://rg-api.azurewebsites.net/api/Product/getproductcollectionssalon";
        public bool isCustomer = true; //temporary

        //Get Request
        public async Task<List<ProductCollection>> GetProductCollections()
        {
            var client = new HttpClient();

            var productCollectionsUrl = isCustomer ? GetProductCollectionsForCustomersUrl : GetProductCollectionsForSalonsUrl;

            //send request to server. Server will send response back in JSON format
            var response = await client.GetAsync(productCollectionsUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseValue = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductCollection>>(responseValue);
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
