using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }
        public string ProductionYear { get; set; }

        [Required]
        public string FuelType { get; set; }
        public VehicleType VehicleType { get; set; }
        public byte VehicleTypeId { get; set; }
    }
}