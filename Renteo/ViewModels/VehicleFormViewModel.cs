using Renteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Renteo.ViewModels
{
    public class VehicleFormViewModel
    {
        public IEnumerable<VehicleType> VehicleTypes { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}