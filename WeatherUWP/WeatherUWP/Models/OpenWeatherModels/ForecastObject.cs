﻿using System;
using System.Collections.Generic;

namespace WeatherUWP.Models.OpenWeatherModels
{
    public class ForecastObject
    {
        public City City { get; set; }
        public string Cod { get; set; }
        public double Message { get; set; }
        public int Cnt { get; set; }
        public List<List> list { get; set; }
    }
}