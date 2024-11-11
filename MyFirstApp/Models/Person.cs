using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Options;
using MyFirstApp.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApp.Models
{
    public class Person : IValidatableObject
    {
        [Required(ErrorMessage = "{0} Empty or Null")]
        [Display(Name = "Person Name")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1}")]
        [RegularExpression("^[A-Za-z .]*$", ErrorMessage = "{0} should contains only alphabets, space and dot")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [EmailAddress(ErrorMessage = "{0} should be a proper email, like : (example1@gmail.com)")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid {0}")]
        //[ValidateNever] // temp stopping for validation
        public string? PhoneNumber { get; set; }


        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{1} and {0} don't match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }


        [Range(1500, 100000, ErrorMessage = "{0} should be between {1} and {2}")]
        public double? Salary { get; set; }

        [MinimumYearValidator(2002)]
        //[BindNever]
        public DateTime? DateOfBirth { get; set; }
        
        public int? Age { get; set; }

        public List<string?> Tags { get; set; } = new List<string?>();


        public DateTime? FromDate { get; set; }
        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' should be older than or equal 'To date'")]
        public DateTime? ToDate { get; set; }

        public override string ToString()
        {
            return $"Person name : {PersonName}" +
                $", Email : {Email}, Phone : {PhoneNumber}" +
                $"Password : {Password}, Confirm Password : {ConfirmPassword}, " +
                $"Salary : {Salary}, " +
                $"Tags[0]: {Tags[0]}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext vacon)
        {
            if (DateOfBirth.HasValue == false && Age.HasValue == false)
            {
                yield return new ValidationResult("Either Date of birth of Age must " +
                    "be supplied", new[] {nameof(Age)});
            }
        }
    }
}
