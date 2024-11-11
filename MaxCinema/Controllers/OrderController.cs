using Microsoft.AspNetCore.Mvc;

namespace MaxCinema.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
