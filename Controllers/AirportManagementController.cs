using System.Linq;
using Airhub.Data;
using Airhub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airhub.Controllers
{
    public class AirportManagementController : Controller
    {
        private AppDbContext _context;

        public AirportManagementController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("airportManagement")]
        public ViewResult AirportsManagement()
        {
            var airports = _context.Airports;
            return View(airports);
        }

        public ActionResult deleteAirport(int Id)
        {
            try
            {
                _context.Airports.Remove(_context.Airports.Find(Id));
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction("ErrorAirportConstraint", _context.Airports.Find(Id));
            }
            return RedirectToAction("AirportsManagement");
        }

        [HttpPost]
        public ActionResult AddAirport(string name, string city)
        {
            var airport = new Airport(name, city);
            _context.Add<Airport>(airport);
            _context.SaveChanges();
            return RedirectToAction("AirportsManagement");
        }

        [Route("errorAirportConstraint")]
        public ViewResult ErrorAirportConstraint(Airport? airport)
        {
            return View(airport);
        }
    }
}