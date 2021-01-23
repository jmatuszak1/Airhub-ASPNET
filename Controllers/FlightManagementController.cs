using System.Linq;
using Airhub.Data;
using Airhub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Airhub.ViewModel;

namespace Airhub.Controllers
{
    public class FlightManagementController : Controller
    {
        private AppDbContext _context;

        public FlightManagementController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("flightManagement")]
        public ViewResult FlightsManagement(Flight? flight)
        {
            var flights = _context.Flights
                .Include(a => a.ArrivalAirport)
                .Include(b => b.DepartureAirport)
                .Include(b => b.Plane);
            var viewModel = new AddFlightViewModel()
            {
                Flights = flights.ToList()
            };
            return View(flights);
        }

        public ActionResult deleteFlight(int Id)
        {
            _context.Flights.Remove(_context.Flights.Find(Id));
            _context.SaveChanges();
            return RedirectToAction("FlightsManagement");
        }

        [HttpPost]
        public ActionResult AddFlight(int departureAirportId, int arrivalAirportId, string departureDate, string arrivalDate, int seats, int planeId)
        {
            string[] wordsDeparture = departureDate.Split('-');
            DateTime departureDateTime = new DateTime(Int32.Parse(wordsDeparture[0]), Int32.Parse(wordsDeparture[1]),
                Int32.Parse(wordsDeparture[2]));

            string[] wordsArrival = arrivalDate.Split('-');
            DateTime arrivalDateTime = new DateTime(Int32.Parse(wordsArrival[0]), Int32.Parse(wordsArrival[1]),
                Int32.Parse(wordsArrival[2]));

            var flight = new Flight(
                _context.Airports.Find(departureAirportId),
                _context.Airports.Find(arrivalAirportId),
                departureDateTime,
                arrivalDateTime,
                seats,
                _context.Planes.Find(planeId)
            );
            _context.Add<Flight>(flight);
            _context.SaveChanges();
            return RedirectToAction("FlightsManagement");
        }

    }
}