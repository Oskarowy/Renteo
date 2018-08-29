using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.Models
{
    public class Rental
    {
        private TimeSpan _length;

        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime DateReturned {
            get
            {
                return DateReturned;
            }
            set
            {
                DateRented.AddDays(2);
            }
        }

        public int Length { get; set; }

        public double TotalCost { get; set; }

        public Rental()
        {
            _length = DateReturned - DateRented;
            Length = _length.Days;
            TotalCost = (Vehicle.RentalStake * Length) * ((100-Customer.MembershipType.DiscountRate)/100);
        }



    }
}