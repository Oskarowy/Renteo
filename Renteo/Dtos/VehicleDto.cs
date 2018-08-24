using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string ProductionYear { get; set; }

        [Required]
        public string FuelType { get; set; }

        [Required]
        public byte VehicleTypeId { get; set; }
    }
}