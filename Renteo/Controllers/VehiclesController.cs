using Renteo.Models;
using Renteo.ViewModels;
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

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomVehicleViewModel
            {
                Vehicle = vehicle,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ViewResult Index()
        {
            var vehicles = GetVehicles();

            return View(vehicles);
        }

        private IEnumerable<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                new Vehicle { Id = 1, Make = "Opel Insignia" },
                new Vehicle { Id = 2, Make = "Ford Mondeo" },
             };
        }
    }
}