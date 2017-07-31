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
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string data = await response.Content.ReadAsStringAsync();

                return await Task.Run(() => JsonConvert.DeserializeObject<T>(data));
            }
        }
    }
}
