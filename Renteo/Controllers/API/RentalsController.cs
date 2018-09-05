using AutoMapper;
using Renteo.Dtos;
using Renteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Renteo.Controllers.API
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Rentals/all
        [Route("api/rentals/all")]
        public IHttpActionResult GetRentals()
        {
            var rentalDto = _context.Rentals
                .Include( c => c.Customer)
                .Include( c => c.Vehicle)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalDto);
        }

        // GET: api/Rentals/CustomerId
        [Route("api/rentals/my/{id}")]
        public IHttpActionResult GetMyRentals(int id)
        {
            string accountId = User.Identity.GetUserId();
            var customer = _context.Customers.Single(c => c.AccountId == accountId);
            int customerId = customer.Id;

            if (customerId == 0)
                return NotFound();

            var rentalDto = _context.Rentals
                .Include(c => c.Customer)
                .Include(c => c.Vehicle)
                .Where(c => c.CustomerId == customerId)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDto>);

            return Ok(rentalDto);
        }

        // GET: api/Rentals/5
        public IHttpActionResult GetRental(int id)
        {
            var rental = _context.Rentals.SingleOrDefault(r => r.Id == id);

            if (rental == null)
                return NotFound();

            return Ok(Mapper.Map<Rental, RentalDto>(rental));
        }

        // PUT: api/Rentals/5
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult UpdateRental(int id, RentalDto rentalDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rental = _context.Rentals.Single(r => r.Id == id);

            if (rental == null)
                return NotFound();

            Mapper.Map(rentalDto, rental);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Rentals/5
        [HttpDelete]
        public IHttpActionResult DeleteRental(int id)
        {
            var rental = _context.Rentals.Include(v => v.Vehicle).Single(r => r.Id == id);

            if (rental == null)
                return NotFound();

            rental.Vehicle.IsRented = false;
            _context.Rentals.Remove(rental);
            _context.SaveChanges();

            return Ok();
        }
    }
}
