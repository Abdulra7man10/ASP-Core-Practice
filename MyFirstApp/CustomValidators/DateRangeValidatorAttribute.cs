using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MyFirstApp.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute
    {
        public string OtherProp { get; set; }
        public DateRangeValidatorAttribute() { }
        public DateRangeValidatorAttribute(string value) 
        { 
            OtherProp = value;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime to_date = Convert.ToDateTime(value);
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherProp);
                if (otherProperty != null)
                {
                    DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
                    if (from_date > to_date)
                    {
                        return new ValidationResult(ErrorMessage, new string[]
                        { OtherProp, validationContext.MemberName });
                    }
                    else
                        return ValidationResult.Success;
                }
                else
                    return null;
            }
            return null;
        }
    }
}
