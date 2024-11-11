using Microsoft.AspNetCore.Mvc;

namespace MaxCinema.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
