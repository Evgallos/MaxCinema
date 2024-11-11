using MaxCinema.Data;
using MaxCinema.Models;
using MaxCinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaxCinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateMovie()
        {
            return View();
        }
        public IActionResult DeleteMovie()
        {
            return View();
        }
        public IActionResult Display()
        {
            return View();
        }
    }
}

