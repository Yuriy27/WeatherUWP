using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherUWP.Models;
using WeatherUWP.Models.OpenWeatherModels;

namespace WeatherUWP.Services
{
    class HistoryService : RestApiService, IHistoryService
    {
        //private const string Host = "http://localhost:53545";

        public async Task<IEnumerable<History>> GetHistory()
        {
            return await GetApiRequest<IEnumerable<History>>($"{Host}/api/v1/history");
            //using (HttpClient client = new HttpClient())
            //{
            //    var response = await client.GetAsync($"{Host}/api/v1/history");
            //    response.EnsureSuccessStatusCode();
            //    string data = await response.Content.ReadAsStringAsync();

            //    return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<History>>(data));
            //}
        }
    }
}
