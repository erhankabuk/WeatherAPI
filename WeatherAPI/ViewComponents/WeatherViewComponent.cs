using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPI.Models;

namespace WeatherAPI.ViewComponents
{
    public class WeatherViewComponent: ViewComponent
    {
        //Http Client
        HttpClient httpClient = new HttpClient();
        public async Task<IViewComponentResult> InvokeAsync(string city)
        {
            try
            {
            //Create base http uri
            httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
            // Create Http Response
            HttpResponseMessage resp = await httpClient.GetAsync($"?q={city}&appid=API&units=metric");
            //Read Message
            dynamic data = await resp.Content.ReadAsAsync<ExpandoObject>();
            WeatherViewModel vm = new WeatherViewModel() { 
            City=data.name,
            Temperature=data.main.temp,
            Description=data.weather[0].description
            };
            return View(vm);
            }
            catch (Exception)
            {
                return View(null);
            }




        } 


    }
}
