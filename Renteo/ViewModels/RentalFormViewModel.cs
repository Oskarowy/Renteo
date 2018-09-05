using Renteo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.ViewModels
{
    public class RentalFormViewModel
    {
        public int? Id { get; set; }

        public int CustomerId { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        [Display(Name = "Wybierz pojazd z listy")]
        public int VehicleId { get; set; }

        public IEnumerable<Vehicle> Vehicles { get; set; }

        [Display(Name = "Data wynajęcia")]
        public DateTime DateRented { get; set; }

        [Display(Name = "Data zwrotu")]
        public DateTime DateReturned { get; set; }

        public int Length { get; set; }

        public double TotalCost { get; set; }

        public RentalFormViewModel()
        {
            Id = 0;
            DateRented = DateTime.Now;
            DateReturned = DateTime.Now;
        }

        public RentalFormViewModel(Rental rental)
        {
            Id = rental.Id;
            CustomerId = rental.CustomerId;
            VehicleId = rental.VehicleId;
            DateRented = rental.DateRented;
            DateReturned = rental.DateReturned;
            Length = rental.Length;
            TotalCost = rental.TotalCost;
        }
    }
}