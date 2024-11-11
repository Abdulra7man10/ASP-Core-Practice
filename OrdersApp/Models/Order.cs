using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using OrdersApp.CustomValidators;
using OrderSolution.CustomValidators;

namespace OrdersApp.Models
{
    public class Order
    {
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between {1} and {2}")]
        [Display(Name = "OrderNumber")]
        public int? OrderNo { get; set; }
        
        [MinimumYearValidator]
        public DateTime OrderDate { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between {1} and {2}")]
        [InvoicePriceValidator]
        public double InvoicePrice { get; set; }

        [ProductsListValidator]
        public List<Product?> Products { get; set; } = new List<Product?>();

        /*public override string ToString()
        {
            var random = new Random();
            OrderNo = random.Next(1, 99999);
            string invoice = Convert.ToString(OrderNo) + '\n';

            invoice += Convert.ToString(OrderDate) + '\n';
            foreach (var product in Products) {
                if (product != null)
                    invoice += product + "\n";
            }

            invoice += Convert.ToString(InvoicePrice);
            return invoice;
        }
        */
    }
}
