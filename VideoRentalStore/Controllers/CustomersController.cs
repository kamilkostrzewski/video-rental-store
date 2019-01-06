using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalStore.Models;
using VideoRentalStore.ViewModels;

namespace VideoRentalStore.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers/Details
        public ActionResult Index()
        {
            var customers = new CustomersViewModel
            {
                Customers = new List<Customer>
                {
                    new Customer {Id = 1, Name = "Adam Smith"},
                    new Customer {Id = 2, Name = "Glen Johnson"}
                }
            };
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = new CustomersViewModel
            {
                Customers = new List<Customer>
                {
                    new Customer {Id = 1, Name = "Adam Smith"},
                    new Customer {Id = 2, Name = "Glen Johnson"}
                }
            };
            foreach (var customer in customers.Customers)
            {
                if (customer.Id == id)
                {
                    return View(customer);
                }
            }
            return HttpNotFound();
        }
    }
}