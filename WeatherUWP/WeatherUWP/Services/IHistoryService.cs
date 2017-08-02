using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherUWP.Models;

namespace WeatherUWP.Services
{
    interface IHistoryService
    {
        Task<List<History>> GetHistoryAsync();
    }
}
