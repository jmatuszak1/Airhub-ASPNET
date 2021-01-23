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
    public class CustomerController : Controller
    {


        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PersonalData
        public async Task<IActionResult> Index(int id = 15)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int id = 15)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }


        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName, DateOfBirth,Gender,DocumentNumber")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customerDb = _context.Customers.SingleOrDefault(x => x.Id == id);
                    customerDb.FirstName = customer.FirstName;
                    customerDb.LastName = customer.LastName;
                    customerDb.DateOfBirth = customer.DateOfBirth;
                    customerDb.Gender = customer.Gender;
                    customerDb.DocumentNumber = customer.DocumentNumber;

                    _context.Update(customerDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

    }
}

