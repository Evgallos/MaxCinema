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

        public IActionResult Create() 
        {
            return View();
        }

        public IActionResult DisplayAll() 
        {
            return View();
        }
    }
}
