using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Form_validation.Models
{
    public class Person
    {
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Invalid format")]
        public string Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z.,\""'\-]+$", ErrorMessage = "Only alphabet characters and . , \" '- are allowed")]
        public string Name { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Maximum length is 10 characters")]
        [RegularExpression(@"^[^\s]*$", ErrorMessage = "Spaces are not allowed")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]@student\.aiub\.edu$", ErrorMessage = "Invalid email format")]
        [Compare("Id", ErrorMessage = "Id and email must matched")]
        public string Email { get; set; }

    }
    public class CompareIdWithEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = (Person)validationContext.ObjectInstance;
            var email = (string)value;

            var atIndex = email.IndexOf('@');
            if (atIndex == -1)
            {
                return new ValidationResult("Invalid email format");
            }

            var idFromEmail = email.Substring(0, atIndex);

            if (idFromEmail != person.Id)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}