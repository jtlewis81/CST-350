using AJAXDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AJAXDemo.Controllers
{
    public class CustomerController : Controller
    {
        List<CustomerModel> customers = new List<CustomerModel>();
        public CustomerController()
        {
            customers.Add(new CustomerModel(0, "JT", 42));
            customers.Add(new CustomerModel(1, "Matt", 32));
            customers.Add(new CustomerModel(2, "Courtney", 31));
            customers.Add(new CustomerModel(3, "Xander", 19));
            customers.Add(new CustomerModel(4, "Brandon", 8));
            customers.Add(new CustomerModel(5, "Brooklyn", 6));
        }


        public IActionResult Index()
        {
            return View(customers);
        }

        public IActionResult ShowOnePerson(int id)
        {
            return PartialView(customers.FirstOrDefault(c => c.Id == id));
        }
    }
}
