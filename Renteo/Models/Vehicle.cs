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

        [Display(Name = "Rok produkcji")]
        [Required]
        public string ProductionYear { get; set; }

        [Display(Name = "Rodzaj paliwa")]
        [Required]
        public string FuelType { get; set; }

        public VehicleType VehicleType { get; set; }

        [Display(Name = "Typ pojazdu")]
        [Required]
        public byte VehicleTypeId { get; set; }

        [Required]
        [Display(Name = "Czynsz dzienny")]
        public double RentalStake { get; set; }

        public bool IsRented { get; set; } = false;
    }
}