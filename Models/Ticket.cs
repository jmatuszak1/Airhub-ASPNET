using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airhub.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int MyProperty { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public int Passenger { get; set; }
        public Flight PassengerId { get; set; }

    }
}
