﻿using System;
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
    class HistoryService : RestApiClient, IHistoryService
    {

        public async Task<IEnumerable<History>> GetHistoryAsync()
        {
            return await GetApiRequestAsync<IEnumerable<History>>($"{Host}/api/v1/history");
        }
    }
}
