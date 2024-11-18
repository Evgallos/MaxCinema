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
            if(_customerService.GetCustomerByEmail(customer.EmailAddress)==null)
            {
                _customerService.Create(customer);
                TempData["EmailCheck"] = "Congs! You are successfully registered!";
                return View();
            }
           
            else
            {
                TempData["EmailCheck"]= "This email address is already registered!";
                return View();
            }           
        }

        public IActionResult DisplayAll() 
        {
            var customerList =_customerService.GetAll();
            return View(customerList);
        }
    }
}
