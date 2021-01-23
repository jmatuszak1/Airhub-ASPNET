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

        public FlightController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("flights")]
        public ViewResult Flights(Flight? flight)
        {
            var flights = _context.Flights
                .Include(a => a.ArrivalAirport)
                .Include(b => b.DepartureAirport)
                .Include(b => b.Plane);
            return View(flights);
        }

        [HttpPost]
        public ViewResult FindFlightsByDepartureAirport(string departureAirport)
        {
            var flights = _context.Flights.Where(a => a.DepartureAirport.Name == departureAirport)
                .Include(a => a.ArrivalAirport)
                .Include(b => b.DepartureAirport)
                .Include(b => b.Plane);
            return View("Flights", flights);
        }

        [HttpPost]
        public ViewResult FindFlightsByArrivalAirport(string arrivalAirport)
        {
            var flights = _context.Flights.Where(a => a.ArrivalAirport.Name == arrivalAirport)
                .Include(a => a.ArrivalAirport)
                .Include(b => b.DepartureAirport)
                .Include(b => b.Plane);
            return View("Flights", flights);
        }
        
        [HttpPost]
        public ViewResult FindFlightsByDepartureDate(string departureDate)
        {
            string[] words = departureDate.Split('-');
            DateTime departureDateTime = new DateTime(Int32.Parse(words[0]), Int32.Parse(words[1]), 
                Int32.Parse(words[2]));
            var flights = _context.Flights
                .Include(a => a.ArrivalAirport)
                .Include(b => b.DepartureAirport)
                .Include(b => b.Plane);
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
