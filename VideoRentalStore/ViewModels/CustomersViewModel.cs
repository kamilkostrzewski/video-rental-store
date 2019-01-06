using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalStore.Models;

namespace VideoRentalStore.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
    }
}