using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Models
{
    public class WeatherViewModel
    {
        public string City{ get; set; }
        public double Temperature { get; set; }
        public string  Description { get; set; }
    }
}
