using Renteo.Dtos;
using Renteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var vehicles = _context.Vehicles.Where(
                v => newRental.VehicleIds.Contains(v.Id)).ToList();

            foreach (var vehicle in vehicles)
            {
                if (!vehicle.IsRented)
                {
                    var rental = new Rental
                    {
                        Customer = customer,
                        Vehicle = vehicle,
                        DateRented = DateTime.Now
                    };

                    vehicle.IsRented = true;
                    _context.Rentals.Add(rental);
                } 
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
