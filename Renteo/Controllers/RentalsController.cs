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

            var vehicles = _context.Vehicles.ToList();

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

            double result = 0;
            double total = 0;
            int discount = 0;
            int discountRate = 0;

            if (rental.Id == 0)
            {
                rental.Length = (rental.DateReturned - rental.DateRented).Days;
                rental.TotalCost = rental.Vehicle.RentalStake * rental.Length;

                discount = rental.Customer.MembershipType.DiscountRate;
                /////////////////////////////////////////////
                // I don't know why but when it is in one line, it always return 0 :(
                if (discount != 0)
                {
                    discountRate = discount - 100;
                    total = -discountRate * rental.TotalCost;
                    result = total / 100;
                    rental.TotalCost = result;
                }
                //////////////////////////////////////////////
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
    }



}