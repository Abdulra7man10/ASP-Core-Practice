using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Home Page";
            List<City> cities = new List<City> 
            {
                new City()
                {
                    CityUniqueCode = "LDN", 
                    CityName = "London", 
                    DateAndTime = new DateTime(2030, 1, 1, 8, 0, 0),  
                    TemperatureFahrenheit = 33
                },
                new City()
                {
                    CityUniqueCode = "CAI", 
                    CityName = "Cairo", 
                    DateAndTime = new DateTime(2030, 1, 1, 8, 0, 0),  
                    TemperatureFahrenheit = 82
                },
                new City()
                {
                    CityUniqueCode = "PAR", 
                    CityName = "Paris", 
                    DateAndTime = new DateTime(2030, 1, 1, 8, 0, 0),  
                    TemperatureFahrenheit = 60
                }
            };
            return View("Index", cities);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            ViewData["appTitle"] = "Details Page";
            if (cityCode == null)
                return Content("City Code can't be null");

            List<City> cities = new List<City> 
            {
                new City()
                {
                    CityUniqueCode = "LDN", 
                    CityName = "London", 
                    DateAndTime = new DateTime(2030, 1, 1, 8, 0, 0),  
                    TemperatureFahrenheit = 33
                },
                new City()
                {
                    CityUniqueCode = "CAI", 
                    CityName = "Cairo", 
                    DateAndTime = new DateTime(2030, 1, 1, 8, 0, 0),  
                    TemperatureFahrenheit = 82
                },
                new City()
                {
                    CityUniqueCode = "PAR", 
                    CityName = "Paris", 
                    DateAndTime = new DateTime(2030, 1, 1, 8, 0, 0),  
                    TemperatureFahrenheit = 60
                }
            };
            
            City matchingCity = cities.Where(t => t.CityUniqueCode == cityCode)
                                          .FirstOrDefault();
            
            if (matchingCity == default || matchingCity == null)
                return Content("City not found");

            return View(matchingCity);
        }
    }
}