using Renteo.Models;
using Renteo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Renteo.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult New()
        { 

            return View();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageVehicles))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageVehicles)]
        public ActionResult Edit(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(v => v.Id == id);

            if (rental == null)
                return HttpNotFound();

            var viewModel = new RentalFormViewModel(rental)
            {
                Customers = _context.Customers.ToList(),
                Vehicles = _context.Vehicles.ToList()
            };

            return View("RentalForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Rental rental)
        {
            var rentalInDb = _context.Rentals.Single(v => v.Id == rental.Id);

                rentalInDb.Id = rental.Id;
                rentalInDb.CustomerId = rental.CustomerId;
                rentalInDb.VehicleId = rental.VehicleId;
                rentalInDb.DateRented = rental.DateRented;
                rentalInDb.DateReturned = rental.DateReturned;
                rentalInDb.Length = rental.Length;
                rentalInDb.TotalCost = rental.TotalCost;

            _context.SaveChanges();

            return RedirectToAction("List", "Rentals");
        }
    }



}