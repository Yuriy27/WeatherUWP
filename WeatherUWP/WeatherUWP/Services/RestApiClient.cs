using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherUWP.Models.OpenWeatherModels;

namespace WeatherUWP.Services
{
    class RestApiClient
    {
        public const string Host = "http://localhost:53545";

        protected async Task<T> GetApiRequestAsync<T>(string url) where T : class
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<T>(data));
            }
        }

        protected async Task PostApiRequestAsync(string url, object requestData)
        {
            using (var client = new HttpClient())
            {
                var req = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, req);
                response.EnsureSuccessStatusCode();
            }
        }

        protected async Task DeleteApiRequestAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
            }
        }

        protected async Task PutApiRequestAsync(string url, object requestData)
        {
            using (var client = new HttpClient())
            {
                var req = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");
                var response = await client.PutAsync(url, req);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
