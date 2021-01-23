using Airhub.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Airhub.ViewModels
{
    public class RegisterViewModel
    {
        [PersonalData]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        [Display(Name = "Document Number")]
        public string DocumentNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
