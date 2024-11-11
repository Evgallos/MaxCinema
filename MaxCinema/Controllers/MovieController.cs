using Microsoft.AspNetCore.Mvc;

namespace MaxCinema.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
