using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Airhub.Data;
using Airhub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Airhub.Controllers
{
    public class FlightController : Controller
    {
        private AppDbContext _context;

        public FlightController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("flights")]
        public ViewResult Flights(Flight? flight)
        {
            var flights = _context.Flights
                .Include(a => a.ArrivalCity)
                .Include(b => b.DepartureCity);
            return View(flights);
        }

        [HttpPost]
        public ViewResult FindFlightsByDepartureCity(string departureCity)
        {
            var flights = _context.Flights.Where(a => a.DepartureCity.Name == departureCity)
                .Include(a => a.ArrivalCity)
                .Include(b => b.DepartureCity);
            return View("Flights", flights);
        }

        [HttpPost]
        public ViewResult FindFlightsByArrivalCity(string arrivalCity)
        {
            var flights = _context.Flights.Where(a => a.ArrivalCity.Name == arrivalCity)
                .Include(a => a.ArrivalCity)
                .Include(b => b.DepartureCity);
            return View("Flights", flights);
        }
        
        [HttpPost]
        public ViewResult FindFlightsByDepartureDate(string departureDate)
        {
            string[] words = departureDate.Split('-');
            DateTime departureDateTime = new DateTime(Int32.Parse(words[0]), Int32.Parse(words[1]), 
                Int32.Parse(words[2]));
            var flights = _context.Flights
                .Include(a => a.ArrivalCity)
                .Include(b => b.DepartureCity);
            var filteredFlights = new Collection();
            foreach (var flight in flights)
            {
                if (flight.DepartureDate.Year == departureDateTime.Year 
                    && flight.DepartureDate.Month == departureDateTime.Month
                    && flight.DepartureDate.Day == departureDateTime.Day)
                {
                    filteredFlights.Add(flight);
                }
            }
            return View("Flights", filteredFlights);
        }
    }
}
