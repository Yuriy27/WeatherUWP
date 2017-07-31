﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherUWP.Models.OpenWeatherModels
{
    public class List
    {
        public int Dt { get; set; }
        public Temperature Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public List<Weather> Weather { get; set; }
        public double Speed { get; set; }
        public int Deg { get; set; }
        public int Clouds { get; set; }
        public double Rain { get; set; }
    }
}