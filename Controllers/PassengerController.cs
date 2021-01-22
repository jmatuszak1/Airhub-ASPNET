using Airhub.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airhub.Models;
using Microsoft.EntityFrameworkCore;

namespace Airhub.Controllers
{
    public class PassengerController : Controller
    {
        private readonly AppDbContext _context;

        public PassengerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: List of flights
        public async Task<IActionResult> AllReservations ()
        {
            return View(await _context.Passengers.Include( x => x.Flight).ThenInclude( f => f.ArrivalAirport).
                                        Include(x => x.Flight).ThenInclude(f => f.DepartureAirport).ToListAsync());
        }
        //GET CUSTOMER'S FLIGHTS
        public async Task<IActionResult> Index(int id = 16)
        {

            var passengers = await _context.Passengers.Where(j => j.CustomerId.Equals
          (id)).Include(x => x.Flight).ThenInclude(f => f.ArrivalAirport).
                                        Include(x => x.Flight).ThenInclude(f => f.DepartureAirport).ToListAsync();
            var filteredPassengers = passengers.Where(x => x.Flight.DepartureDate >= DateTime.Now).ToList();
            return View("Index", filteredPassengers);
        }
        //GET CUSTOMER'S HISTORY FLIGHTS
        public async Task<IActionResult> MyFlightsHistory(int id = 16)
        {
            var passengers =  await _context.Passengers.Where(j => j.CustomerId.Equals
           (id)).Include(x => x.Flight).ThenInclude(f => f.ArrivalAirport).
                                        Include(x => x.Flight).ThenInclude(f => f.DepartureAirport).ToListAsync();
            var filteredPassengers = passengers.Where(x => x.Flight.DepartureDate < DateTime.Now).ToList();
            return View("Index", filteredPassengers);
        }


        // GET: PassengerController/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: PassengerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PassengerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PassengerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PassengerController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _context.Passengers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Jokes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var joke = await _context.Passengers.FindAsync(id);
            _context.Passengers.Remove(joke);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
