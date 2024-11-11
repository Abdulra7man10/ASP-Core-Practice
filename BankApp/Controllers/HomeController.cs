using Microsoft.AspNetCore.Mvc;

namespace BankApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Hello()
        {
            return Content("Welcome to the best Bank");
        }

        [Route("/account-details")]
        public IActionResult Details()
        {
            object holder = new
            {
                accountNumber = 1001,
                HolderName = "Abdulrahman Ahmed",
                currentBalance = 5000
            };
            return Json(holder);
        }

        [Route("/account-statement")]
        public IActionResult Statement()
        {
            return File("/abdoCv.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetBalance(int? accountNumber)
        {
            if (!accountNumber.HasValue)
            {
                return NotFound("Account Number should be supplied");
            }

            if (accountNumber != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }

            return RedirectToAction("Balance", "Account", new { id = accountNumber.Value });
        }

    }
}
