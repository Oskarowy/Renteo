using Renteo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Renteo.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Vehicles
        public ActionResult Random()
        {
            var vehicle = new Vehicle()
            {
                Make = "Opel",
                Model = "Insignia"
            };

            return View(vehicle);
        }
    }
}