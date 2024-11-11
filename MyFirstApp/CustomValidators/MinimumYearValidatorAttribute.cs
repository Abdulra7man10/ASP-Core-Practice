using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Date of birth should be more than {0}";
        public MinimumYearValidatorAttribute() { }
        public MinimumYearValidatorAttribute(int minimumYear) 
        {
            MinimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            if (value != null) 
            {
                DateTime date = (DateTime)value;
                if (date.Year < MinimumYear)
                    return new ValidationResult(string.Format(DefaultErrorMessage, MinimumYear));
                else 
                    return ValidationResult.Success;
            }
            return new ValidationResult("Date is required.");
        }
    }
}
