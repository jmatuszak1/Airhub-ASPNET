using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Airhub.Data;
using Airhub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
            var flights = _context.Flights
                .Include(a => a.ArrivalAirport)
                .Include(b => b.DepartureAirport)
                .Include(b => b.Plane)
                .ToList();

            var flightsByDepartureAirport = GetFlightsByDepartureAirport(flights, departureAirport);

            return View("Flights", flightsByDepartureAirport);
        }

        public List<Flight> GetFlightsByDepartureAirport(List<Flight> flights, string departureAirport)
        {
            return (from flight in flights
                where flight.DepartureAirport.Name == departureAirport
                select flight).ToList();
        }

        [HttpPost]
        public ViewResult FindFlightsByArrivalAirport(string arrivalAirport)
        {
            var flights = _context.Flights
                .Include(a => a.ArrivalAirport)
                .Include(b => b.DepartureAirport)
                .Include(b => b.Plane)
                .ToList();

            var flightsByArrivalAirport = GetFlightsByArrivalAirport(flights, arrivalAirport);

            return View("Flights", flightsByArrivalAirport);
        }

        public List<Flight> GetFlightsByArrivalAirport(List<Flight> flights, string arrivalAirport)
        {
            return (from flight in flights
                where flight.ArrivalAirport.Name == arrivalAirport
                select flight).ToList();
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
                .Include(b => b.Plane)
                .ToList();
            var flightsByDepartureDateGreaterThan = GetflightsByDepartureDateGreaterThan(flights, departureDateTime);
            return View("Flights", flightsByDepartureDateGreaterThan);
        }

        public List<Flight> GetflightsByDepartureDateGreaterThan(List<Flight> flights, DateTime departureDateTime)
        {
            return (from flight in flights
                where flight.DepartureDate > departureDateTime
                    select flight).ToList();
        }
    }
}
