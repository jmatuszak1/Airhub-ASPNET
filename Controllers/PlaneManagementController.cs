using System.Linq;
using Airhub.Data;
using Airhub.Models;
using Microsoft.AspNetCore.Mvc;

namespace Airhub.Controllers
{
    public class PlaneManagementController : Controller
    {
        private AppDbContext _context;

        public PlaneManagementController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("planeManagement")]
        public ViewResult PlanesManagement(Plane? flight)
        {
            var planes = _context.Planes;
            return View(planes);
        }
        
        public ActionResult deletePlane(int Id)
        {
            _context.Planes.Remove(_context.Planes.Find(Id));
            _context.SaveChanges();
            return RedirectToAction("PlanesManagement");
        }

        [HttpPost]
        public ActionResult AddPlane(string name, int seats)
        {
            var plane = new Plane(name, seats);
           _context.Add<Plane>(plane);
            _context.SaveChanges();
           return RedirectToAction("PlanesManagement");
        }

    }
}
