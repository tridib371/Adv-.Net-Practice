using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_3_form_validation.Models
{
    public class Student
    {
        [Required]
        [RegularExpression(@"^[A-Za-z.\-\s]+$", ErrorMessage = "Name can contain only letters, dots, dashes, and spaces.")]
        public string Name {  get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters.")]
        [RegularExpression(@"^\S+$", ErrorMessage = "Username must not contain spaces.")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]{1}$", ErrorMessage = "Id must follow the format: xx-xxxxx-x (x = digit, last digit 1-3).")]
        public string Id { get; set; }


        [Required]
        [EmailMatchesId(ErrorMessage = "Email must be in the format: xx-xxxxx-x@student.aiub.edu where xx-xxxxx-x matches your ID.")]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]

        public string Profession { get; set; }
        [Required]

        public string[] Hobbies { get; set; }

        public DateTime Dob { get; set; }

        //public Student() {
        //    Dob = DateTime.Now;
        //}



        //extra


        // ✅ Custom attribute for exact email validation
        public class EmailMatchesIdAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                var student = (Student)validationContext.ObjectInstance;
                var email = value as string;

                if (!string.IsNullOrWhiteSpace(student.Id) && !string.IsNullOrWhiteSpace(email))
                {
                    var expectedEmail = $"{student.Id}@student.aiub.edu";
                    if (email.Equals(expectedEmail, StringComparison.OrdinalIgnoreCase))
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                }

                return ValidationResult.Success;
            }
        }

    }
}