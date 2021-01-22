using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Airhub.Validation;
using System.Text;

namespace Airhub.Models
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Document number")]
        public string DocumentNumber { get; set; }

        public IList<Passenger> UserFlights { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }

    }
}
