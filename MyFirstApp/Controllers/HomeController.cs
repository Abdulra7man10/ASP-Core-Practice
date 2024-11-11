using Microsoft.AspNetCore.Mvc;
using MyFirstApp.CustomModelBinders;
using MyFirstApp.Models;

namespace MyFirstApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        /// [ModelBinder(BinderType =typeof(PersonModelBinder))]
        public IActionResult Index(Person person,
            [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n",ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            return Content($"{person}\n{UserAgent}");
        }
    }
}

