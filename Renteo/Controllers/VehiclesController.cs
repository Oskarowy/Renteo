using Renteo.Models;
using Renteo.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Renteo.Controllers
{
    public class VehiclesController : Controller
    {
        private ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            var vehicles = _context.Vehicles.Include(v => v.VehicleType).ToList();

            return View(vehicles);
        }

        public ActionResult Details(int id)
        {
            var vehicle = _context
                .Vehicles
                .Include(v => v.VehicleType)
                .SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
                return HttpNotFound();

            return View(vehicle);
        }

    }
}