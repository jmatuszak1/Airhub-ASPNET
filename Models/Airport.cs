using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airhub.Models
{
    public class Airport
    {
        public int Id { get; set; }

        [MaxLength(64)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [MaxLength(64)]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [InverseProperty("DepartureAirport")]
        public IList<Flight> Departures { get; set; }

        [InverseProperty("ArrivalAirport")]
        public IList<Flight> Arrivals { get; set; }

        public Airport()
        {
        }

        public Airport(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}
