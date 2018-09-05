using AutoMapper;
using Microsoft.AspNet.Identity;
using Renteo.Models;
using Renteo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
            string accountId = User.Identity.GetUserId();
            var customer = _context.Customers.Single(c => c.AccountId == accountId);
            int customerId = customer.Id;

            if (customerId == 0)
                return HttpNotFound();

            var vehicles = _context.Vehicles
                .Include(c => c.VehicleType)
                .Where(c => c.IsRented == false)
                .ToList();

            var viewModel = new RentalFormViewModel
            {
                Vehicles = vehicles,
                CustomerId = customerId
            };

            return View("New", viewModel);
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
            var vehicle = _context.Vehicles.Include(v => v.VehicleType).Single(v => v.Id == rental.VehicleId);
            var customer = _context.Customers.Include(c => c.MembershipType).Single(c => c.Id == rental.CustomerId);
            rental.Vehicle = vehicle;
            rental.Customer = customer;

            if (rental.Id == 0)
            {
                rental.calculateLength();
                rental.calculateTotalCost();

                rental.Vehicle.IsRented = true;
                _context.Rentals.Add(rental);
            }
            else
            {
                var rentalInDb = _context.Rentals.Single(v => v.Id == rental.Id);

                Mapper.Map(rental, rentalInDb);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Rentals");
        }

        public ActionResult Details(int id)
        {
            var rental = _context
                .Rentals
                .Include(v => v.Vehicle)
                .Include(c => c.Customer)
                .Include(t => t.Customer.MembershipType)
                .Include(t => t.Vehicle.VehicleType)
                .SingleOrDefault(r => r.Id == id);

            if (rental == null)
                return HttpNotFound();

            rental.IsActive = false;
            rental.Vehicle.IsRented = false;
            rental.calculateLengthTillToday();
            rental.calculateTotalCost();

            _context.SaveChanges();

            return View(rental);
        }
    }



}