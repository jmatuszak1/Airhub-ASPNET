using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airhub.Models
{
    public enum Gender
    {
        MALE,
        FEMALE,
        OTHER
    }
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Płeć")]
        public Gender Gender { get; set; }

        [Required]
        [RegularExpression("A-Za-z1-9")]
        [Display(Name = "Numer dokumentu tożsamości")]
        public string DocumentNumber { get; set; }

        public IList<Passenger> UserFlights { get; set; }

        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }

    }
}
