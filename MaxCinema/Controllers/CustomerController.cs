using MaxCinema.Helper;
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
            {//pass data via TempData from controller/action to view
                TempData["EmailCheck"]= "This email address is already registered!";
                return View();
            }           
        }

        public IActionResult DisplayAll() 
        {
            var customerList =_customerService.GetAll();
            return View(customerList);
        }

        //CustomerCheckIn: Navbar "Customer" button goes to check in page then to display orders
        public IActionResult CustomerCheckIn()
        {
            return View();
        }
        //<input "name"=inputEmail>, pass data via "Post" method "Submit" button
        [HttpPost]
        public IActionResult CustomerCheckIn(string inputEmail) 
        {
            var customer = _customerService.GetCustomerByEmail(inputEmail);
            if (customer == null)
            {//pass data via TempData from controller/action to controller/action
                TempData["EmailCheck"] = "This email is not registered. Become our member now!";
                return RedirectToAction("CreateCustomer", "Customer");
            }
            else
            {                
                return RedirectToAction("CustomerOrderDisplay", "Order", new {email = inputEmail});
            }
        }

        
        public IActionResult Edit(int id)
        {
            var customer = _customerService.GetById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _customerService.Edit(customer);
            return RedirectToAction("DisplayAll");
        }

    }
}
