using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Renteo.Models
{
    public class VehicleType
    {
        public byte Id { get; set; }
        public string BodyType { get; set; }
        public byte PeopleCapacity { get; set; }
    }
}