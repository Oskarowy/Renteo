using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime DateRented { get; set; }

        [ReturnDateLaterOrEqualRentDate]
        public DateTime DateReturned { get; set; }

        public bool IsActive { get; set; } = true;

        public int Length { get; set; }

        public double TotalCost { get; set; }

        public void calculateLength()
        {
            Length = (DateReturned - DateRented).Days + 1;
        }

        public void calculateLengthTillToday()
        {
            DateTime actualReturnDate = DateTime.Now;
            DateReturned = actualReturnDate;
            if (DateRented.CompareTo(DateReturned) > 0)
            {
                DateRented = actualReturnDate;
                Length = 0;
            }
                
            else Length = (DateReturned - DateRented).Days + 1;
        }

        public void calculateTotalCost()
        {
            double result = 0;
            double total = 0;
            int discount = 0;
            int discountRate = 0;

            TotalCost = Vehicle.RentalStake * Length;

            discount = Customer.MembershipType.DiscountRate;
            /////////////////////////////////////////////
            // I don't know why but when it is in one line, it always return 0 :(
            if (discount != 0)
            {
                discountRate = discount - 100;
                total = -discountRate * TotalCost;
                result = total / 100;
                TotalCost = result;
            }
            //////////////////////////////////////////////
            ///
        }
    }
}