using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Renteo.Dtos
{
    public class RentalCostDto
    {
        public int Id { get; set; }

        public RentalDto Rental { get; set; }

        public int RentalId { get; set; }

        public int RentalLength { get; set; }

        public double TotalCost { get; set; }

        private TimeSpan _length { get; set; }

        public RentalCostDto(RentalDto rental)
        {
            _length = rental.DateReturned - rental.DateRented;
            RentalLength = _length.Days;
            TotalCost = (RentalLength * rental.Vehicle.RentalStake) * ((100 - rental.Customer.MembershipType.DiscountRate) / 100);
        }
    }
}