using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherUWP.Models.OpenWeatherModels;

namespace WeatherUWP.Services
{
    interface IForecastService
    {
        Task<ForecastObject> GetForecast(string city, int days);
    }
}
