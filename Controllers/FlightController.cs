using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airhub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ViewResult Flights()
        {
            var flights = _context.Flights
                .Include(a => a.ArrivalCity)
                .Include(b => b.DepartureCity);
            return View(flights);
        }
    }
}
