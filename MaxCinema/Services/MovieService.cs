using MaxCinema.Controllers;
using MaxCinema.Data;
using MaxCinema.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace MaxCinema.Services
{
    public class MovieService: IMovieService
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
            var movieList = _db.Movies.OrderBy(m => m.Title).ToList();
            return movieList;
        }
    }
}

