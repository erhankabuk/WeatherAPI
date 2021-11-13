﻿
-Get your own Api Key from https://openweathermap.org/current

-Create entity class in "Models" folder
-Create an folder as "ViewComponents" in project
-Create a ....ViewComponent file in "ViewComponents" which is inherited from "ViewComponent"
-Code in ....ViewComponent Task

-Create Components folder in Shared folder
-Create a .... folder in Components.
-Create defaılt.cshtml file in .... and bind @model

-Arrange _Layout.cshtml and add @RenderBody() in body section

- Add Tag helper in _ViewImport.cshtml  as   @addTagHelper *, WeatherAPI

-Create http client in ....VievComponent.cs
HttpClient httpClient = new HttpClient();
-Create base http uri in Task
 httpClient.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
 -Create HttpResponse
  HttpResponseMessage resp = await httpClient.GetAsync($"?q={city}&appid=API=metric");
  -install a package for ReadAsAsync
  Install-Package Microsoft.AspNet.WebApi.Client paste in Package Manager Console

  -Read Message From Response
  dynamic data = await resp.Content.ReadAsAsync<ExpandoObject>();

  -Create ViewModel object and assigne values
  //https://openweathermap.org/current
  //api.openweathermap.org/data/2.5/weather?q=ankara&appid=API&units=metric
   WeatherViewModel vm = new WeatherViewModel() { 
            City=data.name,
            Temperature=data.main.temp,
            Description=data.weather[0].description
            };           

            return View(vm);

