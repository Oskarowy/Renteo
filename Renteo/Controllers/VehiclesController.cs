using Renteo.Models;
using Renteo.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

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

        public ViewResult New()
        {
            var vehicleTypes = _context.VehicleTypes.ToList();

            var viewModel = new VehicleFormViewModel
            {
                VehicleTypes = vehicleTypes
            };

            return View("VehicleForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new VehicleFormViewModel(vehicle)
                {
                    VehicleTypes = _context.VehicleTypes.ToList()
                };

                return View("VehicleForm", viewModel);
            }

            if (vehicle.Id == 0)
                _context.Vehicles.Add(vehicle);
            else
            {
                var vehicleInDb = _context.Vehicles.Single(v => v.Id == vehicle.Id);

                vehicleInDb.Make = vehicle.Make;
                vehicleInDb.Model = vehicle.Model;
                vehicleInDb.ProductionYear = vehicle.ProductionYear;
                vehicleInDb.FuelType = vehicle.FuelType;
                vehicleInDb.VehicleTypeId = vehicle.VehicleTypeId;
                
            }

                _context.SaveChanges();
       
            return RedirectToAction("Index", "Vehicles");
        }

        public ActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(v => v.Id == id);

            if (vehicle == null)
                return HttpNotFound();

            var viewModel = new VehicleFormViewModel(vehicle)
            {
                VehicleTypes = _context.VehicleTypes.ToList()
            };

            return View("VehicleForm", viewModel);
        }

    }
}