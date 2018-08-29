using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Renteo.Models;
using System.Web.Mvc;
using Renteo.Dtos;
using AutoMapper;

namespace Renteo.Controllers.API
{
    public class RentalCostsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalCostsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/rentalcosts
        public IHttpActionResult GetRentalCosts()
        {
            var rentalCostDto = _context.RentalCosts
                .Include(c => c.Rental)
                .ToList()
                .Select(Mapper.Map<RentalCost, RentalCostDto>);

            return Ok(rentalCostDto);
        }

        //GET api/rentalcosts/1
        public IHttpActionResult GetRentalCost(int id)
        {
            var rentalCost = _context.RentalCosts.SingleOrDefault(r => r.Id == id);

            if (rentalCost == null)
                return NotFound();

            return Ok(Mapper.Map<RentalCost, RentalCostDto>(rentalCost));
        }

        // PUT: api/rentalcosts/5
        public IHttpActionResult UpdateRentalCost(int id, RentalCostDto rentalCostDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rentalCost = _context.RentalCosts.Single(r => r.Id == id);

            if (rentalCost == null)
                return NotFound();

            Mapper.Map(rentalCostDto, rentalCost);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/rentalcosts/5
        public IHttpActionResult DeleteRentalCost(int id)
        {
            var rentalCost = _context.RentalCosts.Single(r => r.Id == id);

            if (rentalCost == null)
                return NotFound();

            _context.RentalCosts.Remove(rentalCost);
            _context.SaveChanges();

            return Ok();
        }
    }
}
