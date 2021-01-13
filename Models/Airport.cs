using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airhub.Models
{
    public class Airport
    {
        public int Id { get; set; }

        [StringLength(3), Required]
        [RegularExpression("[A-Z]")]
        public string IATA { get; set; }

        [MaxLength(64)]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [MaxLength(64)]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [InverseProperty("DepartureCity")]
        public IList<Flight> Departures { get; set; }

        [InverseProperty("ArrivalCity")]
        public IList<Flight> Arrivals { get; set; }
    }
}
