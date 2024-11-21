using MaxCinema.Data;
using MaxCinema.Models;
using MaxCinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var movies =_movieService.GetListAll();
            return View(movies);
        }
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateMovie(Movie movie)
        {
            if (ModelState.IsValid)
            _movieService.Create(movie);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteMovie()
        {
            return View();
        }
        public IActionResult Display()
        {
            return View();
        }
        public IActionResult DetailMovie(int id)
        {
            var movie = _movieService.Get(id);
            return View(movie);
        }
    }
}

