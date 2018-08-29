using Renteo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public CustomerDto Customer { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public VehicleDto Vehicle { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime DateReturned { get; set; }
    }
}