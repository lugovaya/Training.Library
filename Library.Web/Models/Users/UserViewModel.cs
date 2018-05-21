using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Library.Web.Infrastructure.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Models.Users
{
    public class UserViewModel : IValidatableObject
    {
        [Required]
        [PersonName]
        public string Name { get; set; }
        
        [Required]
        [Remote("IsUnique", "Users", AdditionalFields = "Name")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [Compare("Password", ErrorMessage = "Password should equals")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}