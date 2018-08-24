using AutoMapper;
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
    public class VehiclesController : ApiController
    {
        private ApplicationDbContext _context;

        public VehiclesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/vehicles
        public IEnumerable<VehicleDto> GetVehicles()
        {
            return _context.Vehicles.ToList().Select(Mapper.Map<Vehicle, VehicleDto>);
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
        public IHttpActionResult UpdateVehicle(int id, VehicleDto vehicleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var vehicleInDb = _context.Vehicles.SingleOrDefault(c => c.Id == id);

            if (vehicleInDb == null)
                return NotFound();

            Mapper.Map(vehicleDto, vehicleInDb);

            _context.SaveChanges();

            return Ok(vehicleDto);
        }

        // DELETE /api/vehicles/1
        [HttpDelete]
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
