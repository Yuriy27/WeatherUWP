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
        public async Task<List<City>> GetDefaultCitiesAsync()
        {
            return await GetApiRequestAsync<List<City>>($"{Host}/api/v1/cities");
        }

        public async Task DeleteCityAsync(int id)
        {
            await DeleteApiRequestAsync($"{Host}/api/v1/cities/{id}");
        }

        public async Task UpdateCityAsync(City city)
        {
            await PutApiRequestAsync($"{Host}/api/v1/cities", city);
        }

        public async Task AddCityAsync(City city)
        {
            await PostApiRequestAsync($"{Host}/api/v1/cities", city);
        }
    }
}
