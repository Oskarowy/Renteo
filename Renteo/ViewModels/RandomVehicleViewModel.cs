using Renteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Renteo.ViewModels
{
    public class RandomVehicleViewModel
    {
        public Vehicle Vehicle { get; set; }
        public List<Customer> Customers { get; set; }
    }
}