using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Renteo.Models
{
    public class RentalCost
    {
        public int Id { get; set; }

        public Rental Rental { get; set; }

        public int RentalId { get; set; }

        public int RentalLength { get; set; }

        public double TotalCost { get; set; }

        private TimeSpan _length { get; set; }

        public RentalCost(Rental rental)
        {
            _length = rental.DateReturned - rental.DateRented;
            RentalLength = _length.Days;
            TotalCost = (RentalLength * rental.Vehicle.RentalStake) * ((100 - rental.Customer.MembershipType.DiscountRate) / 100);
        }
    }
}