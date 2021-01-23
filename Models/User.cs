using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airhub.Models
{
    public class User : IdentityUser
    {
        
        [Required]
        [MaxLength(64)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Document Number")]
        public string DocumentNumber { get; set; }

        public IList<Passenger> UserFlights { get; set; }

    }
}
