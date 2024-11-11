using Microsoft.AspNetCore.Mvc;

namespace MaxCinema.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
