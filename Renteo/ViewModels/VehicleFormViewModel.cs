using Renteo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.ViewModels
{
    public class VehicleFormViewModel
    {
        public IEnumerable<VehicleType> VehicleTypes { get; set; }

        public int? Id { get; set; }

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

        [Display(Name = "Vehicle Type")]
        [Required]
        public byte? VehicleTypeId { get; set; }

        public VehicleFormViewModel()
        {
            Id = 0;
        }

        public VehicleFormViewModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            Make = vehicle.Make;
            Model = vehicle.Model;
            FuelType = vehicle.FuelType;
            ProductionYear = vehicle.ProductionYear;
            VehicleTypeId = vehicle.VehicleTypeId;
        }
    }
}