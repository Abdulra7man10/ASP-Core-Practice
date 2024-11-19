using Microsoft.AspNetCore.Mvc;
using RazorApp.Models;

namespace RazorApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Index Page";
            List<Person> people = new List<Person>() { 
                new Person() 
                { 
                    Name = "Abdo", 
                    DateOfBirth = Convert.ToDateTime("2004-07-15"),
                    PersonGender = Gender.Male
                },
                new Person() 
                { 
                    Name = "Ali", 
                    DateOfBirth = Convert.ToDateTime("2002-10-15"),
                    PersonGender = Gender.Male
                },
                new Person() 
                { 
                    Name = "Mona", 
                    DateOfBirth = Convert.ToDateTime("2000-01-15"),
                    PersonGender = Gender.Female
                },
            };
            return View("Index", people);
        }

        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
                return Content("person name can't be null");
            List<Person> people = new List<Person>() { 
                new Person() 
                { 
                    Name = "Abdo", 
                    DateOfBirth = Convert.ToDateTime("2004-07-15"),
                    PersonGender = Gender.Male
                },
                new Person() 
                { 
                    Name = "Ali", 
                    DateOfBirth = Convert.ToDateTime("2002-10-15"),
                    PersonGender = Gender.Male
                },
                new Person() 
                { 
                    Name = "Mona", 
                    DateOfBirth = Convert.ToDateTime("2000-01-15"),
                    PersonGender = Gender.Female
                },
            };

            Person matchingPerson = people.Where(t => t.Name == name)
                                          .FirstOrDefault();
            return View(matchingPerson);
        }


    }
}