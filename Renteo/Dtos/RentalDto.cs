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
        public Customer Customer { get; set; }

        [Required]
        public Vehicle Vehicle { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; } 
    }
}