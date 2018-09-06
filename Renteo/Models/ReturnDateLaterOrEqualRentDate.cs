using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Renteo.Models
{
    public class ReturnDateLaterOrEqualRentDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rental = (Rental)validationContext.ObjectInstance;

            if (rental.DateRented.CompareTo(rental.DateReturned) > 0)
                return new ValidationResult("Data zwrotu nie może być wcześniejsza, niż data wypożyczenia.");
            
            return ValidationResult.Success;
        }
    }
}