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
    class ForecastService : RestApiClient, IForecastService
    {
        public async Task<ForecastObject> GetForecastAsync(string city, int days)
        {
            return await GetApiRequestAsync<ForecastObject>($"{Host}/api/v1/forecast/{city}/{days}");
        }
    }
}
