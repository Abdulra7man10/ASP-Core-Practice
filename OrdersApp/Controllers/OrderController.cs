using Microsoft.AspNetCore.Mvc;
using OrdersApp.Models;
using System;

namespace BankApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("/order")]
        public IActionResult Index([Bind(nameof(Order.OrderDate), 
            nameof(Order.InvoicePrice), nameof(Order.Products))] Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage));
                return BadRequest(errors);
            }
            var random = new Random();
            order.OrderNo = random.Next(1, 99999);
            return Json(new {OrderNumber = order.OrderNo});
        }

    }
}
