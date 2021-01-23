﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airhub.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public int Seat { get; set; }
        public int Price { get; set; } = 500;

    }
}
