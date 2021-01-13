using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airhub.Models
{
    public class Passenger
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
