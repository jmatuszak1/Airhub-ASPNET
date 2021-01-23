using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airhub.Data;
using Airhub.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airhub.Controllers
{
    public class AddPlaneController : Controller
    {
        private AppDbContext _context;

        public AddPlaneController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult AddPlane()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPlane(Plane plane)
        {
            if (ModelState.IsValid)
            {
                _context.Add<Plane>(plane);
                _context.SaveChanges();
                return Redirect(Url.Content("~/planeManagement"));
            }
            return View();
        }
    }
}
