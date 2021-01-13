using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airhub.Models
{
    public class Plane
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(64)]
        [Display(Name = "Model")]
        public string Name { get; set; }

        [Required]
        [Range(0,300)]
        [Display(Name = "Liczba miejsc")]
        public int Seats { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
