using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Renteo.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> VehicleIds { get; set; }
    }
}