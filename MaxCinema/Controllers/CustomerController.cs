using MaxCinema.Models;
using MaxCinema.Services;
using Microsoft.AspNetCore.Mvc;

namespace MaxCinema.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateCustomer() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _customerService.Create(customer);
            return View();
        }

        public IActionResult DisplayAll() 
        {
            var customerList =_customerService.GetAll();
            return View(customerList);
        }
    }
}
