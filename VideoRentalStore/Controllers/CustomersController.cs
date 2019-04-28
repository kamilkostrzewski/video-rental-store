using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VideoRentalStore.Models;
using VideoRentalStore.ViewModel;

namespace VideoRentalStore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers
                    .Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);

            if (customers == null)
            {
                return HttpNotFound();
            }

            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}