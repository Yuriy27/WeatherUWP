using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherUWP.Models;

namespace WeatherUWP.Services
{
    class CityService : RestApiClient, ICityService
    {
        public async Task<IEnumerable<City>> GetDefaultCitiesAsync()
        {
            return await GetApiRequestAsync<IEnumerable<City>>($"{Host}/api/v1/cities");
        }
    }
}
