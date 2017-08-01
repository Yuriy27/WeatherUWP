using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherUWP.Models;

namespace WeatherUWP.Services
{
    interface ICityService
    {
        Task<IEnumerable<City>> GetDefaultCitiesAsync();

        Task DeleteCityAsync(int id);

        Task UpdateCityAsync(City city);

        Task AddCityAsync(City city);
    }
}
