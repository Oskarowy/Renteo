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

        [Display(Name = "Production Year")]
        [Required]
        public string ProductionYear { get; set; }

        [Display(Name = "Fuel Type")]
        [Required]
        public string FuelType { get; set; }

        public VehicleType VehicleType { get; set; }

        [Display(Name = "Vehicle Type")]
        [Required]
        public byte VehicleTypeId { get; set; }

        public bool IsRented { get; set; } = false;
    }
}