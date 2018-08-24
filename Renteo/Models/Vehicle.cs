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

        public string Make { get; set; }

        public string Model { get; set; }

        [Display(Name = "Production Year")]
        public string ProductionYear { get; set; }

        [Display(Name = "Fuel Type")]
        public string FuelType { get; set; }

        public VehicleType VehicleType { get; set; }

        [Display(Name = "Vehicle Type")]
        public byte VehicleTypeId { get; set; }
    }
}