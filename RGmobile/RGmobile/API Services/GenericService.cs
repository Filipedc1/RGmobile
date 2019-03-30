using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RGmobile.API_Services
{
    // Add Polly library for retry 
    public class GenericService
    {
        //public async Task<T> GetAsync<T>(string uri, string authToken = "")
        //{
        //    try
        //    {
        //        HttpClient httpClient = CreateHttpClient(uri);
        //        string result = string.Empty;

        //        var responseMessage = await Policy
        //                                    .Handle<WebException>(ex =>
        //                                    {
        //                                        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
        //                                        return true;
        //                                    })
        //                                    .WaitAndRetryAsync
        //                                    (
        //                                        5,
        //                                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        //                                    )
        //                                    .ExecuteAsync(async () => await httpClient.GetAsync(uri));

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            var json = JsonConvert.DeserializeObject<T>(result);
        //            return json;
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Forbidden || responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            throw new ServiceAuthenticationException(result);
        //        }

        //        throw new HttpRequestExceptionEx(responseMessage.StatusCode, result);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
        //        throw;
        //    }
        //}

        //public async Task<T> PostAsync<T>(string uri, T data, string authToken = "")
        //{
        //    try
        //    {
        //        HttpClient httpClient = CreateHttpClient(uri);

        //        var content = new StringContent(JsonConvert.SerializeObject(data));
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        string result = string.Empty;

        //        var responseMessage = await Policy
        //                                    .Handle<WebException>(ex =>
        //                                    {
        //                                        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
        //                                        return true;
        //                                    })
        //                                    .WaitAndRetryAsync
        //                                    (
        //                                        5,
        //                                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        //                                    )
        //                                    .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            var json = JsonConvert.DeserializeObject<T>(result);
        //            return json;
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
        //            responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            throw new ServiceAuthenticationException(result);
        //        }

        //        throw new HttpRequestExceptionEx(responseMessage.StatusCode, result);

        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
        //        throw;
        //    }
        //}

        //public async Task<TR> PostAsync<T, TR>(string uri, T data, string authToken = "")
        //{
        //    try
        //    {
        //        HttpClient httpClient = CreateHttpClient(uri);

        //        var content = new StringContent(JsonConvert.SerializeObject(data));
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        string result = string.Empty;

        //        var responseMessage = await Policy
        //                                    .Handle<WebException>(ex =>
        //                                    {
        //                                        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
        //                                        return true;
        //                                    })
        //                                    .WaitAndRetryAsync
        //                                    (
        //                                        5,
        //                                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        //                                    )
        //                                    .ExecuteAsync(async () => await httpClient.PostAsync(uri, content));

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            var json = JsonConvert.DeserializeObject<TR>(result);
        //            return json;
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
        //            responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            throw new ServiceAuthenticationException(result);
        //        }

        //        throw new HttpRequestExceptionEx(responseMessage.StatusCode, result);

        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
        //        throw;
        //    }
        //}

        //public async Task<T> PutAsync<T>(string uri, T data, string authToken = "")
        //{
        //    try
        //    {
        //        HttpClient httpClient = CreateHttpClient(uri);

        //        var content = new StringContent(JsonConvert.SerializeObject(data));
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        string result = string.Empty;

        //        var responseMessage = await Policy
        //                                    .Handle<WebException>(ex =>
        //                                    {
        //                                        Debug.WriteLine($"{ex.GetType().Name + " : " + ex.Message}");
        //                                        return true;
        //                                    })
        //                                    .WaitAndRetryAsync
        //                                    (
        //                                        5,
        //                                        retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
        //                                    )
        //                                    .ExecuteAsync(async () => await httpClient.PutAsync(uri, content));

        //        if (responseMessage.IsSuccessStatusCode)
        //        {
        //            result = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            var json = JsonConvert.DeserializeObject<T>(result);
        //            return json;
        //        }

        //        if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
        //            responseMessage.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            throw new ServiceAuthenticationException(result);
        //        }

        //        throw new HttpRequestExceptionEx(responseMessage.StatusCode, result);

        //    }
        //    catch (Exception e)
        //    {
        //        Debug.WriteLine($"{ e.GetType().Name + " : " + e.Message}");
        //        throw;
        //    }
        //}

        //public async Task DeleteAsync(string uri, string authToken = "")
        //{
        //    HttpClient httpClient = CreateHttpClient(authToken);
        //    await httpClient.DeleteAsync(uri);
        //}

        //private HttpClient CreateHttpClient(string authToken)
        //{
        //    var httpClient = new HttpClient();
        //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    if (!string.IsNullOrEmpty(authToken))
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
        //    }
        //    return httpClient;
        //}
    }
}
