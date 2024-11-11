using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OrdersApp.Models
{
    public class Product //: IValidatableObject
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between {1} and {2}")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be between {1} and {2}")]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be between {1} and {2}")]
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Product code : {ProductCode}, Price : {Price},"
                + $"Quantity : {Quantity}";
        }
    }
}
