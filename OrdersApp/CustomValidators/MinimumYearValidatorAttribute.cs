using System.ComponentModel.DataAnnotations;

namespace OrdersApp.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public DateTime MinimumYear { get; set; } = new DateTime(2000, 1, 1, 00, 00 ,00);
        public string DefaultErrorMessage { get; set; } = "Order Date should be more than {0}";
        public MinimumYearValidatorAttribute() { }
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime Orderdate = (DateTime)value;
                if (Orderdate < MinimumYear)
                    return new ValidationResult(string.Format(DefaultErrorMessage, MinimumYear));
                else
                    return ValidationResult.Success;
            }
            return new ValidationResult("Order date can't be blank");
        }
    }
}
