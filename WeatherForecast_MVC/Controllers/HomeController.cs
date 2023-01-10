using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WeatherForecast_MVC.Data;
using WeatherForecast_MVC.Models;
using static System.Net.WebRequestMethods;

namespace WeatherForecast_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public async Task<IActionResult> IndexAsync(Weather weather)
        {
            try
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={weather.Place}&appid= YOUR API KEY HERE &units=metric&lang=tr";
                HttpClient client = new HttpClient();

                HttpResponseMessage answer = await client.GetAsync(url);

                string? json = await answer.Content.ReadAsStringAsync();
                dynamic? data = JsonConvert.DeserializeObject(json);
                weather.Temprature = data?.main.temp;

                weather.Description = data.weather[0].description;
                weather.Icon = data.weather[0].icon;
                ViewBag.Icon = $"http://openweathermap.org/img/wn/{weather.Icon}@2x.png";
                
            }
            catch (Exception)
            {

               
            }
                return View(weather);
            
            
            
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}