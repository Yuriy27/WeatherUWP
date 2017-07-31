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
    class ForecastService : RestApiService, IForecastService
    {
        //private const string Host = "http://localhost:53545";

        public async Task<ForecastObject> GetForecast(string city, int days)
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    var response = await client.GetAsync($"{Host}/api/v1/forecast/{city}/{days}");
            //    response.EnsureSuccessStatusCode();
            //    string data = await response.Content.ReadAsStringAsync();

            //    return await Task.Run(() => JsonConvert.DeserializeObject<ForecastObject>(data));
            //}
            return await GetApiRequest<ForecastObject>($"{Host}/api/v1/forecast/{city}/{days}");
        }
    }
}
