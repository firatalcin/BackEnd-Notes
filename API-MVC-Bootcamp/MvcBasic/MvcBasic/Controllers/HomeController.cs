using Microsoft.AspNetCore.Mvc;
using MvcBasic.Models;
using System.Diagnostics;

namespace MvcBasic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var customers = CustomerContext.Customers;
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            var lastCustomer= CustomerContext.Customers.Last();

            var id = lastCustomer.Id + 1;

            CustomerContext.Customers.Add(
                new Customer { 
                    Id = id, 
                    FirstName = customer.FirstName, 
                    LastName = customer.LastName, 
                    Age = customer.Age 
                });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Remove(int id) 
        {

            var customer = CustomerContext.Customers.Find(x => x.Id == id);
            CustomerContext.Customers.Remove(customer);


            return RedirectToAction("Index");
        }
    }
}
