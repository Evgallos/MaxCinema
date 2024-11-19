using MaxCinema.Models;

namespace MaxCinema.Services
{
    public interface IMovieService 
    {
        public void Create(Movie movie);
        public void Delete(Movie movie);
        public List<Movie> GetListAll();
        public Movie Get(int id);
        public decimal GetPrice(int id);

        public List<Movie> GetTopFivePopularMovies();
        public List<Movie> GetTopFiveNewMovies();

        public List<Movie> GetTopFiveOldestMovies();

        public List<Movie> GetTopFiveCheapestMovies();
    }
}
