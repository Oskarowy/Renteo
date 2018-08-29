using Renteo.Dtos;
using Renteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;

namespace Renteo.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            var customer = _context.Customers.Include(c => c.MembershipType).Single(
                c => c.Id == newRental.CustomerId);

            var vehicles = _context.Vehicles.Include(v => v.VehicleType).Where(
                v => newRental.VehicleIds.Contains(v.Id)).ToList();

            double result = 0;
            double total = 0;
            int discount = 0;
            int discountRate = 0;

            foreach (var vehicle in vehicles)
            {
                if (!vehicle.IsRented)
                {
                    var rental = new Rental
                    {
                        Customer = customer,
                        Vehicle = vehicle,
                        DateRented = DateTime.Now,
                        DateReturned = DateTime.Now.AddDays(2),
                        Length = 2,
                        TotalCost = vehicle.RentalStake * 2
                    };
                    // I don't know why but when it is in one line, it always return 0 :(
                    discount = rental.Customer.MembershipType.DiscountRate;
                    discountRate = discount-100;
                    total = -discountRate * rental.TotalCost;
                    result = total / 100;
                    rental.TotalCost = result;
                    vehicle.IsRented = true;
                    _context.Rentals.Add(rental);
                } 
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
