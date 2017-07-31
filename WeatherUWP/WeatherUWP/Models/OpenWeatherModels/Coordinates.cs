using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace WeatherUWP.Models.OpenWeatherModels
{
    public class Coordinates
    {
        [JsonProperty(PropertyName = "lon")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
    }
}