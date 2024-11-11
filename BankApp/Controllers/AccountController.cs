using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class AccountController : Controller
    {
        [Route("/account/balance/{id:int}")]
        public IActionResult Balance(int id)
        {
            return Content($"<p>Current Balance for Account {id} : {5000}</p>", "text/html");
        }
    }
}
