using MaxCinema.Controllers;
using MaxCinema.Data;
using MaxCinema.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace MaxCinema.Services
{
    public class MovieService : IMovieService
    {
        private readonly MCinemaContext _db;
        public MovieService(MCinemaContext db)
        {
            _db = db;
        }
        public void Create(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
        public void Delete(Movie movies)
        {

        }
        public List<Movie> GetListAll()
        {
            var movieList = _db.Movies.OrderBy(m => m.Id).ToList();
            return movieList;
        }

        public Movie Get(int id)
        {
            var movie = _db.Movies.FirstOrDefault(x => x.Id == id);
            return movie!;
        }

        public decimal GetPrice(int id)
        {
            decimal price = _db.Movies.Where(m => m.Id == id).FirstOrDefault().Price;
            return price;
        }

        public List<Movie> GetTopFivePopularMovies()
        {
            return _db.Movies
                    .Include(m => m.OrderRows)
                    .OrderByDescending(o => o.OrderRows.Count())
                    .Take(5)
                    .ToList();
        }

        public List<Movie> GetTopFiveNewMovies()
        {
            return _db.Movies
                .OrderByDescending(m => m.ReleaseYear)
                .Take(5)
                .ToList();

        }

        public List<Movie> GetTopFiveOldestMovies()
        {
            return _db.Movies
               .OrderBy(m => m.ReleaseYear)
               .Take(5)
               .ToList();
        }

        public List<Movie> GetTopFiveCheapestMovies()
        {
            return _db.Movies
              .OrderBy(m => m.Price)
              .Take(5)
              .ToList();
        }
    }
}

