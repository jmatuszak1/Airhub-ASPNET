using Airhub.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Airhub.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Miasto wylotu")]
        public Airport DepartureAirport { get; set; }

        [Required]
        [Display(Name = "Miasto przylotu")]
        public Airport ArrivalAirport { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Termin odlotu")]
        [FlightDateValidator(ErrorMessage = "Data odlotu nie może być w przeszłości!")]
        public DateTime DepartureDate { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Termin przylotu")]
        public DateTime ArrivalDate { get; set; }

        [Range(0, 300)]
        [Display(Name = "Liczba miejsc")]
        public int MaxSeats { get; set; }

        [Range(0, 300)]
        [Display(Name = "Liczba wolnych miejsc")]
        public int OccupiedSeats { get; set; }

        [Display(Name = "Samolot")]
        public Plane Plane { get; set; }

        internal object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public IList<Passenger> Passengers { get; set; }
    }
}
