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
        [Display(Name = "Liczba wolnych miejsc")]
        public int OccupiedSeats { get; set; }

        [Display(Name = "Samolot")]
        public Plane Plane { get; set; }

        public IList<Passenger> Passengers { get; set; }

        public Flight()
        {
        }

        public Flight(Airport departureAirport, Airport arrivalAirport, DateTime departureDate, DateTime arrivalDate, int occupiedSeats, Plane plane)
        {
            DepartureAirport = departureAirport;
            ArrivalAirport = arrivalAirport;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            OccupiedSeats = occupiedSeats;
            Plane = plane;
        }
    }
}
