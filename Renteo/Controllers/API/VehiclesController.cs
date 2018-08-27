using AutoMapper;
using Renteo.Dtos;
using Renteo.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Renteo.Controllers.API
{
    public class VehiclesController : ApiController
    {
        private ApplicationDbContext _context;

        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/vehicles
        public IHttpActionResult GetVehicles(string query = null)
        {
            var vehiclesQuery = _context.Vehicles
                .Include(c => c.VehicleType)
                .Where(c => c.IsRented == false);

            if (!String.IsNullOrWhiteSpace(query))
                vehiclesQuery = vehiclesQuery.Where(c => c.Make.Contains(query));

            var vehicleDto = vehiclesQuery
                .ToList()
                .Select(Mapper.Map<Vehicle, VehicleDto>);

            return Ok(vehicleDto);

        }

        // GET api/vehicles/1
        public IHttpActionResult GetVehicle(int id)
        {
            var vehicle = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicle == null)
                return NotFound();

            return Ok(Mapper.Map<Vehicle, VehicleDto>(vehicle));
        }

        // POST /api/vehicles
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult CreateVehicle(VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vehicle = Mapper.Map<VehicleDto, Vehicle>(vehicleDto);

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            vehicleDto.Id = vehicle.Id;

            return Created(new Uri(Request.RequestUri + "/" + vehicle.Id), vehicleDto);
        }

        // PUT /api/vehicles/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult UpdateVehicle(int id, VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vehicleInDb = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicleInDb == null)
                return NotFound();

            Mapper.Map(vehicleDto, vehicleInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/vehicles/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageVehicles)]
        public IHttpActionResult DeleteVehicle(int id)
        {
            var vehicleInDb = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicleInDb == null)
                return NotFound();

            _context.Vehicles.Remove(vehicleInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
