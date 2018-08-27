using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Renteo.Dtos;

namespace Renteo.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        public string Name {
            get
            {
                return Make + " " + Model;
            }
        }

        [Required]
        public string ProductionYear { get; set; }

        [Required]
        public string FuelType { get; set; }

        public VehicleTypeDto VehicleType { get; set; }

        [Required]
        public byte VehicleTypeId { get; set; }

        public bool IsRented { get; set; } = false;
    }
}